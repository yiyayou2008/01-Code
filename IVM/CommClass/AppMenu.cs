using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CommClass
{
    class AppMenu
    {
        private int menuID;
        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string menuName;
        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        private int parentID;
        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        private Boolean isDetail;
        public Boolean IsDetail
        {
            get { return isDetail; }
            set { isDetail = value; }
        }

    }

    class AppMenuLogic
    {
        private DBSource ds;
        public AppMenuLogic(DBSource myDatasource)
        {
            this.ds = myDatasource;
        }

        private string errorMessage = "";
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        /// <summary>
        /// 取得菜单项列表
        /// </summary>
        /// <param name="ParentID">父项ID</param>
        /// <returns>此父项ID下的所有子项列表</returns>
        public DataView GetMenuList(string ParentID)
        {
            DataSet dataS = new DataSet();

            string strCmd;

            strCmd = "WITH pp (MenuID,Title,MenuName,IsDetail,ParentID) as " +
                    "(SELECT m.MenuID,m.Title,m.MenuName,m.IsDetail,m.ParentID " +
                    "FROM t_menu m " +
                    "where m.ParentID=" + ParentID +
                    " UNION All " +
                    "SELECT m.MenuID,m.Title,m.MenuName,m.IsDetail,m.ParentID " +
                    "FROM t_menu m " +
                    "join PP " +
                    "on m.ParentID=pp.MenuID) " +
                    "select distinct * from pp";
            dataS = ds.GetRecord(strCmd);

            return dataS.Tables[0].DefaultView;
        }

        /// <summary>
        /// 找出节点下的所有叶节点
        /// </summary>
        /// <param name="ParentID">父节点ID</param>
        /// <returns>返回所有叶节点数据集视图</returns>
        public DataView GetUserMenu(string ParentID, string UserCode)
        {
            DataSet dataS = new DataSet();

            string strCmd;
            string TableName;

            if (ParentID.Trim() == "0")
            {
                strCmd = "";
                TableName = "t_menu";
            }
            else
            {
                strCmd = " with PP (MenuID,Title,MenuName,IsDetail,ParentID) as " +
                    "(select MenuID,Title,MenuName,IsDetail,ParentID " +
                    "from t_menu " +
                    "where MenuID= " + ParentID +
                    "union all " +
                    "SELECT m.MenuID,m.Title,m.MenuName,m.IsDetail,m.ParentID " +
                    "from t_menu m " +
                    "join PP " +
                    "on m.ParentID=PP.MenuID " +
                    ") ";
                TableName = "PP";
            }
            strCmd = strCmd +
                "select distinct case when a.MenuID IS NULL then 0 else 1 end HasRight, m.MenuID ,m.Title,m.MenuName,m.IsDetail,m.ParentID " +
                "from " + TableName + " m left join " +
                "(select m.MenuID,m.Title,m.MenuName,m.IsDetail,m.ParentID " +
                "from t_menu m,t_UserRight r,t_User u " +
                "where r.UserID=u.UserID " +
                "and r.MenuID=m.MenuID " +
                "and u.UserCode='" + UserCode + "') a " +
                "on m.MenuID=a.MenuID " +
                "where m.IsDetail=1";

            dataS = ds.GetRecord(strCmd);

            return dataS.Tables[0].DefaultView;
        }

        /// <summary>
        /// 取得要显示的控件清单
        /// </summary>
        /// <param name="_formName">显示的form名</param>
        /// <param name="_userCode">用户代码</param>
        /// <returns></returns>
        public List<string> GetControlList(string _formName, User _user)
        {
            List<string> Result = new List<string>();
            string sqlCmd;
            if (_user.IsAdmin)
            {
                sqlCmd = "select MenuName" +
                    " from t_menu" +
                    " where ParentID =(select MenuID from t_menu where FormName='" + _formName.Trim() + "')";
            }
            else
            {
                sqlCmd = "select MenuName " +
                    " from t_UserRight R,t_User u,t_menu m" +
                    " where R.UserID=u.UserID" +
                    " and R.MenuID=m.MenuID " +
                    " and m.TypeID=1" +
                    " and m.ParentID =(select MenuID from t_menu where FormName='" + _formName.Trim() + "')" +
                    " and u.UserCode='" + _user.UserCode.Trim() + "'";
            }
            DataTableReader dr = ds.GetRecord(sqlCmd).CreateDataReader();
            while (dr.Read())
            {
                Result.Add(dr[0].ToString());
            }
            return Result;
        }
    }
}

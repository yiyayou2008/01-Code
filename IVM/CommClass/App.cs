using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
//using IVM.CommClass;

namespace CommClass
{
    class App
    {

        private static User appUser;
        public static User AppUser
        {
            get { return appUser; }
            set { appUser = value; }
        }

        private static string stIniFileName = "IVM.ini";
        public static string IniFileName
        {
            get { return stIniFileName; }
        }
        private static string stAppPath = Application.StartupPath;
        public static string AppPath
        {
            get { return stAppPath; }
        }
        
        
        private static List<string> messages=new List<string>();
        public static List<string> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private static DBSource ds;
        public static DBSource Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        #region 常用函数

        /// <summary>
        /// 判断字符串是否为整数格式
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>是返回true，否返回false</returns>
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?[0-9]+$");
        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, "^(-?//d+)(//.//d+)?$");
        }
    #endregion

        #region 用户
        /// <summary>
        /// 判断用户代码是否存在
        /// </summary>
        /// <param name="UserCode">用户代码</param>
        /// <returns>存在返回true，否则返回false</returns>
        public static Boolean UserIsExist(string UserCode)
        {
            string strcmd;
            strcmd = "select * from t_user where UserCode='" + UserCode.Trim() + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
                return true;
            else
                return false;
        }

        public static int UserGetMaxID()
        {
            int MaxID;
            string strcmd;
            strcmd = "select Max(UserID) from t_user";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                MaxID = Convert.ToInt32(dr[0]);
            }
            else
            {
                MaxID = 0;
            }
            return MaxID;
        }

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Boolean UserAdd(User user)
        {
            string strCmd;

            strCmd = "insert t_User (UserID,CompanyID,DepartmentID,UserCode,UserName,UserPasswd,UserDescription,UserLevel,IsDisable,usertel) values (" +
                (UserGetMaxID() + 1).ToString() + ",'"+user .CompanyID +"','" +user.DepartmentID +"','"+ user.UserCode + "','" + user.UserName + "','" + user.UserPassword + "','" +
                user.UserDescription + "'," + user.UserLevel.ToString() + ",0,'"+user.UserTel +"')";
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        public static Boolean ChangePasswordByCode(string userCode, string password)
        {
            string strCmd;

            strCmd = "update t_user set UserPasswd='" + password.Trim() + "' where UserCode='" + userCode.Trim() + "'";
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }



        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="updUser"></param>
        /// <returns></returns>
        public static Boolean UserUpdateByCode(User updUser)
        {
            string strCmd;
            

            strCmd = "update t_user set UserName='" + updUser.UserName + "',UserDescription='" +
                updUser.UserDescription + "',Companyid=" + updUser .CompanyID +",Departmentid="+updUser.DepartmentID  +",isdisable='"+updUser.IsDisable +"',usertel='"+updUser .UserTel +"',userlevel="+updUser .UserLevel +" where UserCode='" +
                updUser.UserCode.Trim() + "'";
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public static Boolean UserDeleteByCode(string userCode)
        {
            string strCmd;
            ///todo: 还需要删除t_UserRight表中相关记录
            strCmd = "delete t_user where UserCode='" + userCode + "'";
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        public static List<User> UserGetList()
        {
            List<User> UserList = new List<User>();
            string strCmd;
            strCmd = "select tu.*,tc.companyname,td.departmentname from t_user tu,t_company tc,t_department td where tu.companyid=tc.companyid and tu.departmentid=td.departmentid order by tu.UserCode";
            DataTableReader dr = ds.GetRecord(strCmd).CreateDataReader();
            while (dr.Read())
            {
                User tmpUser = new User();
                tmpUser.UserID = Convert.ToInt32(dr["UserID"]);
                tmpUser.UserCode = dr["UserCode"].ToString();
                tmpUser.UserName = dr["UserName"].ToString();
                tmpUser.CompanyID =Convert.ToInt32(dr["companyid"]);
                tmpUser.DepartmentID= Convert.ToInt32(dr["departmentid"]);
                tmpUser.UserLevel = Convert.ToInt32(dr["UserLevel"]);
                tmpUser.UserDescription = dr["UserDescription"].ToString();
                tmpUser.IsDisable = Convert.ToBoolean(dr["IsDisable"]);
                tmpUser.UserTel = dr["UserTel"].ToString();
                tmpUser.Companyname = dr["companyname"].ToString();
                tmpUser.Departmentname = dr["departmentname"].ToString();
                UserList.Add(tmpUser);
            }
            return UserList;
        }

        public static User UserGetByCode(string usercode)
        {
            User tmpUser = new User();
            string strcmd;
            strcmd = "select * from t_user where UserCode='" + usercode.Trim() + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                tmpUser.UserID = Convert.ToInt32(dr["UserID"]);
                tmpUser.UserCode = dr["UserCode"].ToString();
                tmpUser.UserName = dr["UserName"].ToString();
                tmpUser.UserLevel = Convert.ToInt32(dr["UserLevel"]);
                tmpUser.UserDescription = dr["UserDescription"].ToString();
                tmpUser.IsDisable = Convert.ToBoolean(dr["IsDisable"]);
                tmpUser.UserTel = dr["UserTel"].ToString();
                tmpUser.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                tmpUser.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
               

            }
            else
            {
                tmpUser = null;
            }
            return tmpUser;
        }

        public static User UserInfoGetByCode(string usercode)
        {
            User tmpUser = new User();
            string strcmd;
            strcmd = "select tu.*,tc.companyname,td.departmentname from t_user tu,t_company tc,t_department td where tu.companyid=tc.companyid and tu.departmentid=td.departmentid and tu.UserCode='" + usercode.Trim() + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                tmpUser.UserID = Convert.ToInt32(dr["UserID"]);
                tmpUser.UserCode = dr["UserCode"].ToString();
                tmpUser.UserName = dr["UserName"].ToString();
                tmpUser.UserLevel = Convert.ToInt32(dr["UserLevel"]);
                tmpUser.UserDescription = dr["UserDescription"].ToString();
                tmpUser.IsDisable = Convert.ToBoolean(dr["IsDisable"]);
                tmpUser.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                tmpUser.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                tmpUser.UserTel = dr["UserTel"].ToString();
                tmpUser.Companyname = dr["companyname"].ToString();
                tmpUser.Departmentname = dr["departmentname"].ToString();

            }
            else
            {
                tmpUser = null;
            }
            return tmpUser;
        }
        public static Boolean UserCheck(string userCode, string Password)
        {
            string strcmd;
            //防止SQL注入式攻击
            if (userCode.IndexOf("'") >= 0 || Password.IndexOf("'") >= 0)
                return false;

            strcmd = "select count(*) from t_user where IsDisable=0 and UserCode='" + userCode + "' and UserPasswd='" + Password + "'";
            DataSet Dat = ds.GetRecord(strcmd);
            DataTableReader dr = Dat.CreateDataReader();
            dr.Read();
            if (Convert.ToInt32(dr[0].ToString ())> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static int UserGetIDByCode(string userCode)
        {
            int userID;
            string strcmd;
            strcmd = "select UserID from t_user where UserCode='" + userCode + "'";
            DataSet Dat = ds.GetRecord(strcmd);
            DataTableReader dr = Dat.CreateDataReader();
            if (dr.Read())
                userID = dr.GetInt32(0);
            else
                userID = 0;

            return userID;
        }

        /// <summary>
        /// 取得用户权限
        /// </summary>
        /// <param name="_User"></param>
        public static void GetUserRight(User _User)
        {
            string strcmd;
            strcmd = "select r.MenuID " +
                "from t_UserRight r,t_User u " +
                "where r.UserID=u.UserID " +
                "and u.UserCode ='" + _User.UserCode + "' " +
                "order by MenuID ";
            DataSet Dats = ds.GetRecord(strcmd);
            DataTableReader dr = Dats.CreateDataReader();
            _User.Right.Clear();
            while (dr.Read())
            {
                _User.Right.Add(dr[0].ToString());
            }
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="rightList"></param>
        /// <returns></returns>
        public static  Boolean SetUserRight(User _User)
        {
            string strCmd;
            int userID;
            Boolean Result = true;

            userID = UserGetIDByCode(_User.UserCode);

            strCmd = "delete t_UserRight where UserID=" + userID + "";
            ds.ExecuteSQL(strCmd);

            foreach (string strRight in _User.Right)
            {
                strCmd = "insert t_UserRight (UserID,MenuID,CreateBy,CreateDate) values(" +
                    userID.ToString() + "," + strRight + "," + App.AppUser.UserID.ToString() + ",GetDate())";
                if (!ds.ExecuteSQL(strCmd))
                {
                    messages.Clear();
                    messages.Add(ds.ErrorMessage);
                    Result = false;
                }
            }
            return Result;
        }
        #endregion

        #region 基础资料
        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param ></param>
        /// <returns>保存成功true，否则返回false</returns>
        public static Boolean CompanyAdd(string companycode, string companyname,string companyaddress)
        {
            string strcmd;

            strcmd = "insert t_Company (companycode,companyname,companyaddress) values ('" + companycode + "','" + companyname + "','"+companyaddress +"')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取全部公司信息
        /// </summary>
        public static DataTable GetCompany()
        {
            string strcmd;
            strcmd = "select * from t_company";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取公司ID信息
        /// </summary>
        public static int GetCompanyid(string companyname)
        {
            int companyid;
            string strcmd;
            strcmd = "select companyid from t_company where companyname='" + companyname + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                companyid = Convert.ToInt32(dr[0]);
            }
            else
            {
                companyid = 0;
            }
            return companyid;
        }
        /// <summary>
        /// 获取指定公司信息
        /// </summary>
        public static DataTable GetCompanyByid(string companyid)
        {
            string strcmd;
            strcmd = "select * from t_company where companyid='" + companyid + "'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 更新公司信息
        /// </summary>
        public static Boolean CompanyUpdate(string companyid, string companycode, string companyname,string companyaddress)
        {
            string strcmd;
            strcmd = "update t_company set companycode='" + companycode + "',companyname='" + companyname + "',companyaddress='"+companyaddress +"' where companyid='" + companyid + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param ></param>
        /// <returns>保存成功true，否则返回false</returns>
        public static Boolean DepartmentAdd(string departmentcode, string departmentname)
        {
            string strcmd;

            strcmd = "insert t_Department (departmentcode,departmentname) values ('" + departmentcode + "','" + departmentname + "')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        public static DataTable GetDepartment()
        {
            string strcmd;
            strcmd = "select * from t_department";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取部门ID信息
        /// </summary>
        public static int GetDepartmentid(string departmentname)
        {
            int departmentid;
            string strcmd;
            strcmd = "select departmentid from t_department where departmentname='" + departmentname + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                departmentid = Convert.ToInt32(dr[0]);
            }
            else
            {
                departmentid = 0;
            }
            return departmentid;
        }
        /// <summary>
        /// 获取指定部门信息
        /// </summary>
        public static DataTable GetDepartmentByid(string departmentid)
        {
            string strcmd;
            strcmd = "select * from t_department where departmentid='" + departmentid + "'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 更新部门信息
        /// </summary>
        public static Boolean DepartmentUpdate(string departmentid, string departmentcode, string departmentname)
        {
            string strcmd;
            strcmd = "update t_department set departmentcode='" + departmentcode + "',departmentname='" + departmentname + "' where departmentid='" + departmentid + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 新增快递公司
        /// </summary>
        /// <param ></param>
        /// <returns>保存成功true，否则返回false</returns>
        public static Boolean ExpCompanyAdd(string expcompanyname, string expcompanytel,string printmodel)
        {
            string strcmd;

            strcmd = "insert t_ExpCompany (expcompanyname,exptel,printmodel) values ('" + expcompanyname + "','" + expcompanytel + "','"+printmodel +"')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取全部快递公司信息
        /// </summary>
        public static DataTable GetExpCompany()
        {
            string strcmd;
            strcmd = "select * from t_expcompany";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取全部快递公司信息
        /// </summary>
        public static string GetPrintModel(int excompanyid)
        {
            string strcmd;
            strcmd = "select printmodel from t_expcompany where expcompanyid=" + excompanyid;
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            dr.Read();
            string printmodel = dr[0].ToString();
            return printmodel;

        }
        /// <summary>
        /// 更新快递公司信息
        /// </summary>
        public static Boolean ExpCompanyUpdate(string expcompanyid, string expcompanyname, string exptel,string printmodel)
        {
            string strcmd;
            strcmd = "update t_expcompany set expcompanyname='" + expcompanyname + "',exptel='" +exptel + "',printmodel='"+printmodel +"' where expcompanyid='" +expcompanyid + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取指定快递公司信息
        /// </summary>
        public static DataTable GetExpCompanyByid(string expcompanyid)
        {
            string strcmd;
            strcmd = "select * from t_expcompany where expcompanyid='" + expcompanyid + "'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 新增客户邮寄地址
        /// </summary>
        /// <param ></param>
        /// <returns>保存成功true，否则返回false</returns>
        public static Boolean CustAddressAdd(ExpAddress eadd)
        {
            string strcmd;

            strcmd = "insert t_custexpaddress (CustomerName,CustomerSend,CustAddress,Addressee,CustTel) values ('" + eadd.CustomerName + "','" + eadd .CustomerSend  +"','"+
                      eadd .CustAddress +"','"+eadd.Addressee +"','"+eadd .CustTel +"')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 检查客户信息是否重复
        /// </summary>
        public static Boolean CheckAddress(ExpAddress exd)
        {
            string strcmd;
            strcmd = "select * from t_CustExpAddress where CustomerName='" + exd.CustomerName + "' and CustomerSend='" + exd.CustomerSend + "' and CustAddress='"+exd.CustAddress +
                     "' and Addressee='" + exd.Addressee + "' and CustTel='"+exd.CustTel +"'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
                return true;
            else
                return false;
        }
        /// <summary>
        /// 检查客户信息是否重复
        /// </summary>
        public static Boolean CheckCustomName(ExpAddress exd)
        {
            string strcmd;
            strcmd = "select * from t_CustExpAddress where CustomerName='" + exd.CustomerName + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取全部客户邮寄地址信息
        /// </summary>
        public static DataTable GetCustAddress(string sqlcode)
        {
            string strcmd;
            strcmd = "select * from t_custexpaddress where 1=1 "+sqlcode ;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 根据ID获取邮寄地址信息
        /// </summary>
        public static DataTable GetAddressByid(int custaddressid)
        {
            string strcmd;
            strcmd = "select * from t_custexpaddress where ExpAddressId=" + custaddressid;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 根据客户名称获取邮寄地址信息
        /// </summary>
        public static DataTable GetAddressCustName(string custname)
        {
            string strcmd;
            strcmd = "select * from t_custexpaddress where customername='" + custname+"'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 更新客户邮寄地址信息
        /// </summary>
        public static Boolean ExpAddressUpdate(ExpAddress ead)
        {
            string strcmd;
            strcmd = "update t_custexpaddress set CustomerName='" + ead.CustomerName + "',CustomerSend='" + ead.CustomerSend +"',CustAddress='"+ead.CustAddress +
                     "',Addressee='" + ead.Addressee + "',CustTel='" + ead.CustTel + "' where ExpAddressId=" + ead.ExpAddressId ;
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 检查客户邮寄地址是否是多地址
        /// </summary>
        public static int CountAddress(string custname)
        {
            string strcmd;
            int countadd;
            strcmd = "select count(*) from t_custexpaddress where customername='" + custname + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                countadd  = Convert.ToInt32(dr[0]);
            }
            else
            {
                countadd = 0;
            }
            return countadd;
        }
        /// <summary>
        /// 获取客户地址ID
        /// </summary>
        public static int GetAddressId(string custname)
        {
            string strcmd;
            int addressid;
            strcmd = "select ExpAddressId from t_custexpaddress where customername='" + custname + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
            {
                addressid = Convert.ToInt32(dr[0]);
            }
            else
            {
                addressid = 0;
            }
            return addressid;
        }

        /// <summary>
        /// 张大维
        /// 获取档案室信息 
        /// </summary>
        public static DataTable GetLocation()
        {
            string strcmd;
            strcmd = "SELECT t_Location.LocationID as LocationID,t_Company.CompanyName as CompanyName,t_Location.FileRoomName as FileroomName,t_Location.FileShelfName as FileShelfName,t_Location.FileLayerNum as FileLayerNum FROM t_Company INNER JOIN t_Location ON t_Company.CompanyId = t_Location.CompanyID";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }


        #endregion

        #region 数据库连接
        /// <summary>
        /// 取得数据库连接
        /// 当前程序是从ini文件取（可以在此改为其他方式取）
        /// </summary>
        /// <returns></returns>
        public static DBConnection GetDBConnection()
        {
            DBConnection Result = new DBConnection();

            Encryption encrypt = new Encryption();
            string iniFileName = "";
            const int encryptKey = 1234;
            IniSetting MySettings;
            iniFileName = stAppPath + "\\" + stIniFileName; 
            MySettings = new IniSetting(iniFileName);

            Result.DBServer = MySettings.GetValue("DBConnection", "DBServer");
            Result.DBName = MySettings.GetValue("DBConnection", "DBName");
            Result.UserName = MySettings.GetValue("DBConnection", "UserName");
            Result.Password = encrypt.Decrypt(MySettings.GetValue("DBConnection", "Password"), encryptKey);
            return Result;
        }

        public static void SaveDBConnection(DBConnection _con)
        {
            Encryption encrypt = new Encryption();
            string iniFileName = "";
            const int encryptKey = 1234;
            IniSetting MySettings;
            iniFileName = stAppPath + "\\" + stIniFileName; 
            MySettings = new IniSetting(iniFileName);
            MySettings.SetValue("DBConnection", "DBServer", _con.DBServer);
            MySettings.SetValue("DBConnection", "DBName", _con.DBName);
            MySettings.SetValue("DBConnection", "UserName", _con.UserName);
            MySettings.SetValue("DBConnection", "Password", encrypt.Encrypt(_con.Password, encryptKey));
        }

        public static DBSource ConnectDB(DBConnection _dc)
        {
            DBSource LoginDS;
            LoginDS = new SqlsvrDBSource(_dc);

            if (!LoginDS.Connect())
            {
                messages.Clear();
                messages.Add("数据库服务器连接不正确，请重新设置！错误信息：" + LoginDS.ErrorMessage);
                return null;
            }
            return LoginDS;
        }
        #endregion    

        #region 发票管理
        /// <summary>
        /// 增加发票
        /// </summary>
        /// <returns></returns>
        public static Boolean InvoiceAdd(Invoice inv)
        {
            string strCmd;
            strCmd = "insert t_Invoice (invNumber,companyid,custName,expaddressid,amountNoTax,tax,ismerged,isgetself,inputdate) values('" + inv.InvNumber +"',"+inv.CompanyId + ",'" + inv.Custname + "',0," + inv.AmountNoTax + "," + inv.Tax + ",0,0,'"+inv.Inputdate +"')";
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 检查发票是否存在
        /// </summary>
        public static int InvoiceIsExsit(string invnumber)
        {
            string strcmd;
            int count;
            strcmd = "select invNumber from t_Invoice where invNumber='" + invnumber + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            
            if (dr.Read())
            {
                count = Convert.ToInt32(dr[0]);
            }
                
            else
            {
                count = 0;
            }
            return count;
        }
        /// <summary>
        /// 获取未匹配发票信息
        /// </summary>
        public static DataTable GetInvoice(string sqlcode)
        {
            string strcmd;
            strcmd = "select * from t_Invoice where expaddressid <1 "+sqlcode ;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取未合并发票信息
        /// </summary>
        public static DataTable GetNoMegerInv(string sqlcode)
        {
            string strcmd;
            strcmd = "select iv.invNumber ,iv.custName,ce.CustAddress  from t_CustExpAddress ce,t_Invoice iv where ce.ExpAddressId =iv.ExpAddressId and iv.isMerged =0 and iv.isgetself=0 "+sqlcode+ "order by iv.custName";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 发票邮寄地址匹配
        /// </summary>
        public static Boolean UpdateInvAddressId(string invnumber, int expaddressid)
        {
            string strcmd;
            strcmd = "update t_Invoice set ExpAddressId=" + expaddressid + " where invnumber='" + invnumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 生成发票合并号
        /// </summary>
        public  static string CreatMegerID()
        {
            string iniFileName = Application.StartupPath + "\\" + stIniFileName;
            IniFile inifile = new IniFile(iniFileName);
            string dbDateTime = DateTime.Now.ToString("yy");
            string strcmd = "select max(MegerNumber) from t_express";//查询表中的字段
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            string maxID = "";
            string Result;
            string flag = inifile.ReadValue("Parameter", "MerFlag"); 
            dr.Read();
            if (dr[0].ToString ()!="")
            {
                maxID = dr[0].ToString ();
                //截取字符
                string strFirst = maxID.Substring(2, 2);
                string strLast = maxID.Substring(4, 8);
                if (dbDateTime == strFirst)//截取的最大编号的年份是否和数据库服务器系统时间相等
                {
                    string strNew = (Convert.ToInt32(strLast) + 1).ToString("00000000");//00000000+1
                    Result = flag + dbDateTime + strNew;
                }
                else
                {
                    Result = flag + dbDateTime + "00000001";
                }
            }

            else
            {
                Result = flag + dbDateTime + "00000001";
            }
           
            return Result;
        }

        /// <summary>
        /// 生成发票合并明细记录
        /// </summary>
        public static Boolean MegerExpDescAdd(Express exp)
        {
            string strcmd;
            strcmd = "insert t_expressdesc (megernumber,invnumber) values('" +exp.MegerNumber +"','"+exp.InvNumber +"')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 生成发票合并表头记录
        /// </summary>
        public static Boolean MegerExpAdd(Express exp)
        {
            string strcmd;
            strcmd = "insert t_express (megernumber,ispost,isprint,userid) values('" + exp.MegerNumber + "',0,0,"+exp.UserId +")";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 删除发票合并记录
        /// </summary>
        public static Boolean MegerExpDel(Express exp)
        {
            string strcmd;
            strcmd = "delete t_express where megernumber='" + exp.MegerNumber + "')"+
                     " delete t_expressdesc where megernumber='" + exp.MegerNumber + "')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 更新发票合并后状态
        /// </summary>
        public static Boolean UpdateMegerInv(Express exp)
        {
            string strcmd;
            strcmd = "update t_invoice set ismerged=1 where invnumber='" + exp.InvNumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 更新发票合并后状态
        /// </summary>
        public static Boolean UpdateSelfInv(Express exp)
        {
            string strcmd;
            strcmd = "update t_invoice set isgetself=1 where invnumber='" + exp.InvNumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取未打印的合并单信息
        /// </summary>
        public static DataTable GetUnprintMergeid(string sqlcode)
        {
            string strcmd;
            strcmd = "select distinct te.MegerNumber,tc.CustAddress ,tc.Addressee ,tc.CustTel,tu.UserName " +
                     " from t_Express te,t_ExpressDesc ted,t_Invoice ti ,t_CustExpAddress tc,t_User tu " +
                     " where te.MegerNumber =ted.MegerNumber and ted.invNumber =ti.invNumber and te.IsPrint =0 and tc.ExpAddressId =ti.ExpAddressId and te.UserId =tu.UserID " + sqlcode;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取已打印未发件的合并单信息
        /// </summary>
        public static DataTable GetPrintMerge(string sqlcode)
        {
            string strcmd;
            strcmd = "select distinct te.MegerNumber,tc.CustomerSend ,tc.CustAddress ,tc.Addressee ,tc.CustTel " +
                     " from t_Express te,t_ExpressDesc ted,t_Invoice ti ,t_CustExpAddress tc " +
                     " where te.MegerNumber =ted.MegerNumber and ted.invNumber =ti.invNumber and te.IsPrint =1 and te.ispost=0 and tc.ExpAddressId =ti.ExpAddressId "+sqlcode ;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 获取未打印的发票号
        /// </summary>
        public static DataTable GetUnprintInv(string mergenumber)
        {
            string strcmd;
            strcmd = "select invNumber from t_ExpressDesc where MegerNumber='"+mergenumber +"'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 取消合并的发票号
        /// </summary>
        public static Boolean CancleMegerInv(string invnumber)
        {
            string strcmd;
            strcmd = "delete t_ExpressDesc where invnumber='" +invnumber +"'"+
                     " update t_invoice set ismerged=0 where invnumber='" + invnumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 获取打印信息
        /// </summary>
        public static DataTable GetPrintInfo(string mergenumber)
        {
            string strcmd;
            strcmd = "select te.MegerNumber ,ti.invNumber ,tc.CustomerSend ,tc.CustAddress ,tc.Addressee ,tc.CustTel,tp.CompanyName,tp.companyaddress,(select count(*) from t_ExpressDesc where MegerNumber ='"+mergenumber +"') as countnum "+
                     "from t_CustExpAddress tc,t_Express te ,t_ExpressDesc ted,t_Invoice ti ,t_Company tp "+
                     "where te.MegerNumber =ted.MegerNumber and ted.invNumber =ti.invNumber and ti.ExpAddressId =tc.ExpAddressId and ti.CompanyId =tp.CompanyId  and te.MegerNumber ='"+mergenumber +"'";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        /// <summary>
        /// 通过合并号获取快递公司ID
        /// </summary>
        public static int GetExpIdByMer(string mergenumber)
        {
            string strcmd;
            int expcompanyid;
            strcmd = "select expcompanyid from t_express where MegerNumber='" + mergenumber + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            dr.Read();
            expcompanyid = Convert.ToInt32(dr[0]);
            return expcompanyid;
        }
        /// <summary>
        /// 更新打印状态
        /// </summary>
        public static Boolean UpdatePrint(string mergenumber,int expcompanyid)
        {
            string strcmd;
            strcmd = "update t_express set expcompanyid=" + expcompanyid + ",isprint=1 where megernumber='" + mergenumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 快递单发件
        /// </summary>
        public static Boolean ExpressSend(Express exp)
        {
            string strcmd;
            strcmd = "update t_express set expcompanyid=" + exp.Expcompanyid + ",expnumber='" + exp.ExpNumber + "',expdate='" + exp.Expdate + "',ispost=1 where MegerNumber='" + exp.MegerNumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 修改快递单号
        /// </summary>
        public static Boolean ExpressUpdate(Express exp)
        {
            string strcmd;
            strcmd = "update t_express set expnumber='" + exp.ExpNumber + "' where MegerNumber='" + exp.MegerNumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 检查快递单合法性
        /// </summary>
        public static Boolean CheckExpNumber(string expnumber)
        {
            string strcmd;
            strcmd = "select * from t_express where expnumber='" + expnumber + "'";
             DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
             if (dr.Read())
             
                 return true;
             
             else
                 return false;
        }
        /// <summary>
        /// 检查发票是否合法
        /// </summary>
        public static Boolean CheckInvIsSend(string invnumber)
        {
            string strcmd;
            strcmd = "select * from t_invoice where invnumber='" + invnumber + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())

                return true;

            else
                return false;
        }
        /// <summary>
        /// 获取快递单号
        /// </summary>
        public static string GetExpnumberByMernumber(string mernumber)
        {
            string strcmd;
            string expnumber="";
            strcmd = " select expnumber from t_express where megernumber='" + mernumber + "'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            if (dr.Read())
                expnumber = dr[0].ToString();
            return expnumber;
        }
        /// <summary>
        /// 通过合并号获取邮寄地址ID
        /// </summary>
        public static int GetExpressIdByMer(string mergenumber)
        {
            string strcmd;
            int expressid;
            strcmd = "select distinct ti.ExpAddressId from t_ExpressDesc ted,t_Invoice ti where ted.invNumber =ti.invNumber and ted.MegerNumber ='"+mergenumber +"'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();

            if (dr.Read())
            {
                expressid = Convert.ToInt32(dr[0]);
            }

            else
            {
                expressid = 0;
            }
            return expressid;
        }
        /// <summary>
        /// 通过发票号获取邮寄地址ID
        /// </summary>
        public static int GetExpressIdByIvn(string invnumber)
        {
            string strcmd;
            int expressid;
            strcmd = "select ExpAddressId from t_Invoice where invNumber ='"+invnumber +"'";
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();

            if (dr.Read())
            {
                expressid = Convert.ToInt32(dr[0]);
            }

            else
            {
                expressid = 0;
            }
            return expressid;
        }
        /// <summary>
        /// 通过条件来查询发票和快递信息
        /// </summary>
        public static DataTable GetSerchInfo(string sqlcode)
        {
            string strcmd;
            strcmd = "select te.ExpNumber ,ti.invNumber ,te.ExpDate ,tc.CustomerSend ,tc.CustAddress ,tc.Addressee ,tc.CustTel " +
                   "from t_Express te,t_ExpressDesc ted,t_Invoice ti,t_CustExpAddress tc " +
                   "where te.MegerNumber =ted.MegerNumber and ted.invNumber =ti.invNumber and ti.ExpAddressId =tc.ExpAddressId" + sqlcode +
                   " order by te.ExpDate,ti.invNumber ";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        #endregion

        #region 报表数据
        /// <summary>
        /// 获取快递单明细报表信息
        /// </summary>
        public static DataTable GetRptExpressInfo(string sqlcode)
        {
            string strcmd;
            strcmd = "select distinct te.MegerNumber ,tc.CustomerSend ,tc.CustAddress ,tc.Addressee,te.ExpNumber ,tu.UserName ,te.ExpDate ,tec.ExpCompanyName " +
                   "from t_CustExpAddress tc,t_Express te ,t_ExpressDesc ted,t_Invoice ti ,t_Company tp,t_user tu ,t_ExpCompany tec " +
                   "where te.MegerNumber =ted.MegerNumber and ted.invNumber =ti.invNumber and ti.ExpAddressId =tc.ExpAddressId and ti.CompanyId =tp.CompanyId and tu.UserID =te.UserId and te.ispost=1 and tec.ExpCompanyId =te.ExpCompanyId " + sqlcode;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        #endregion


        #region 凭证管理
        /// <summary>
        /// 导入凭证数据
        /// </summary>
        /// <returns></returns>
        public static Boolean ImportVoucher(Voucher vou)
        {
            string strCmd;
            strCmd = "insert t_Voucher (VoucherNumber,CompanyID,BeginDate,EndDate,VoucherType,IsPutInbox) values('" + vou.VoucherNumber + "'," + vou.CompanyId + ",'" + vou.BeginDate + "','" + vou.EndDate + "','" + vou.VoucherType + "',0" + ")";            
            if (ds.ExecuteSQL(strCmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }
        
        /// <summary>
        /// 获取未入册的凭证信息
        /// </summary>
        public static DataTable GetNoInBoxVoucher(string sqlcode)
        {
            string strcmd;            
            strcmd = "select cp.CompanyCode, cp.CompanyName, vc.VoucherNumber, vc.VoucherType, vc.BeginDate, vc.EndDate from t_Company cp inner join t_Voucher vc on cp.CompanyID = vc.CompanyID where vc.IsPutInBox = 0" + sqlcode;
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }

        /// <summary>
        /// 生成虚拟档案盒编号
        /// </summary>
        public static string CreateFileBoxID()
        {
            string iniFileName = Application.StartupPath + "\\" + stIniFileName;
            IniFile inifile = new IniFile(iniFileName);
            string dbDateTime = DateTime.Now.ToString("yy");
            string strcmd = "select max(FileBoxNumber) from t_FileBox";//取得档案盒最大编号
            DataTableReader dr = ds.GetRecord(strcmd).CreateDataReader();
            string maxID = "";
            string Result;
            string flag = inifile.ReadValue("Parameter", "MerFlag");
            dr.Read();
            if (dr[0].ToString() != "")
            {
                maxID = dr[0].ToString();
                //截取字符
                string strFirst = maxID.Substring(2, 2);
                string strLast = maxID.Substring(4, 8);
                if (dbDateTime == strFirst)//截取的最大编号的年份是否和数据库服务器系统时间相等
                {
                    string strNew = (Convert.ToInt32(strLast) + 1).ToString("00000000");//00000000+1
                    Result = flag + dbDateTime + strNew;
                }
                else
                {
                    Result = flag + dbDateTime + "00000001";
                }
            }

            else
            {
                Result = flag + dbDateTime + "00000001";
            }

            return Result;
        }

        /// <summary>
        /// 生成档案盒表头记录
        /// </summary>
        public static Boolean FileBoxAdd(FileBox fb)
        {
            string strcmd;
            strcmd = "insert t_filebox (fileboxnumber,companyid,locationid,userid,islent) values('" + fb.FileBoxNumber + "'," + fb.CompanyID +"," + 0 + "," + fb.UserID + ",'0')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 更新凭证是否入盒状态
        /// </summary>
        public static Boolean UpdateVoucher(FileBox fb)
        {
            string strcmd;
            strcmd = "update t_voucher set IsPutInBox=1 where VoucherNumber='" + fb.VoucherNumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 生成档案盒表明细记录
        /// </summary>
        public static Boolean FileBoxDescAdd(FileBox fb)
        {
            string strcmd;
            strcmd = "insert t_fileboxdesc (fileboxnumber,vouchernumber) values('" + fb.FileBoxNumber + "','" + fb.VoucherNumber + "')";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 获取未入库的档案盒信息
        /// </summary>
        public static DataTable GetNoLocationFB(string sqlcode)
        {
            string strcmd;
            strcmd = @"select 
                            t_FileBox.FileBoxNumber, t_Company.CompanyCode, t_Company.CompanyName, t_voucher.VoucherNumber, t_Voucher.VoucherType, t_Voucher.BeginDate, t_Voucher.EndDate, t_User.UserName 
                       from 
                            ((((t_FileBox join t_FileBoxDesc on t_FileBox.FileBoxNumber = t_FileBoxDesc.FileBoxNumber) 
                            join t_Voucher on t_FileBoxDesc.VoucherNumber = t_Voucher.VoucherNumber) 
                            join t_Company on t_FileBox.CompanyID = t_Company.CompanyId) 
                            join t_User on t_FileBox.UserID = t_User.UserID)
                            where t_Voucher.IsPutInBox = 1 and t_FileBox.LocationID = 0" + sqlcode;// + "order by t_Filebox.FileBoxNumber";
            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }

        /// <summary>
        /// 更新入库状态
        /// </summary>
        public static Boolean UpdateInbound(string fileboxnumber, int locationid)
        {
            string strcmd;
            strcmd = "update t_FileBox set LocationID=" + locationid + " where FileBoxNumber='" + fileboxnumber + "'";
            if (ds.ExecuteSQL(strcmd))
                return true;
            else
            {
                messages.Clear();
                messages.Add(ds.ErrorMessage);
                return false;
            }
        }

        /// <summary>
        /// 获取未借出的档案盒信息
        /// </summary>
        /// <param name="sqlcode"></param>
        /// <returns></returns>
        public static DataTable GetNoLentFB(string sqlcode)
        {
            string strcmd = "";

            //需要修改完善 2018-02-28 本人先去协调益嘉物流WMS系统上线前准备事宜
            strcmd = @"select 
                            t_FileBox.FileBoxNumber, t_Company.CompanyCode, t_Company.CompanyName, t_voucher.VoucherNumber, t_Voucher.VoucherType, t_Voucher.BeginDate, t_Voucher.EndDate, t_User.UserName 
                       from 
                            ((((t_FileBox join t_FileBoxDesc on t_FileBox.FileBoxNumber = t_FileBoxDesc.FileBoxNumber) 
                            join t_Voucher on t_FileBoxDesc.VoucherNumber = t_Voucher.VoucherNumber) 
                            join t_Company on t_FileBox.CompanyID = t_Company.CompanyId) 
                            join t_User on t_FileBox.UserID = t_User.UserID)
                            where t_Voucher.IsPutInBox = 1 and t_FileBox.LocationID = 0" + sqlcode;

            DataSet dt = ds.GetRecord(strcmd);
            return dt.Tables[0];
        }
        #endregion


    }
}

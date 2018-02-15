using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CommClass
{
    public class User
    {
        private int companyID;
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        private int departmentID;
        public int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userCode;
        public string UserCode
        {
            get { return userCode; }
            set { userCode = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string companyname;
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string departmentname;
        public string Departmentname
        {
            get { return departmentname; }
            set { departmentname = value; }
        }
        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }


        private int userLevel;
        public int UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }

        private string userDescription;
        public string UserDescription
        {
            get { return userDescription; }
            set { userDescription = value; }
        }

        private Boolean isDisable;
        public Boolean IsDisable
        {
            get { return isDisable; }
            set { isDisable = value; }
        }

        private string usertel;
        public string UserTel
        {
            get { return usertel; }
            set { usertel = value; }
        }
        public Boolean IsAdmin
        {
            get { return (userLevel == 0); }
        }

        private List<string> right;
        public List<string> Right
        {
            get { return right; }
        }

        public User()
        {
            right = new List<string>();
        }

        /// <summary>
        /// 判断用户是否有权限
        /// </summary>
        /// <param name="RightID">权限ID</param>
        /// <returns></returns>
        public Boolean HasRight(string RightID)
        {
            return (right.IndexOf(RightID) >= 0);
        }

        /// <summary>
        ///给用户增加权限
        /// </summary>
        /// <param name="RightID"></param>
        public void AddRight(string RightID)
        {
            if (!HasRight(RightID))
                right.Add(RightID);
        }

        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <param name="RightID"></param>
        public void RemoveRight(string RightID)
        {
            if (HasRight(RightID))
                right.Remove(RightID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class FileBox
    {
        private string vouchernumber;
        public string VoucherNumber
        {
            get { return vouchernumber; }
            set { vouchernumber = value; }
        }

        private string fileboxnumber;
        public string FileBoxNumber
        {
            get { return fileboxnumber; }
            set { fileboxnumber = value; }
        }

        private int companyid;
        public int CompanyID
        {
            get { return companyid; }
            set { companyid = value; }
        }

        private int locationid;
        public int LocationID
        {
            get { return locationid; }
            set { locationid = value; }
        }

        private int userid;
        public int UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        private bool islent;
        public bool IsLent
        {
            get { return islent; }
            set { islent = value; }
        }        
    }
}

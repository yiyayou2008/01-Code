using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class Express
    {
        private string invnumber;
        public string InvNumber
        {
            get { return invnumber; }
            set { invnumber = value; }
        }

        private string megernumber;
        public string MegerNumber
        {
            get { return megernumber; }
            set { megernumber = value; }
        }

        private int expcompanyid;
        public int Expcompanyid
        {
            get { return expcompanyid; }
            set { expcompanyid  = value; }
        }

        private string expnumber;
        public string ExpNumber
        {
            get { return expnumber; }
            set { expnumber = value; }
        }

        private DateTime expdate;
        public DateTime Expdate
        {
            get { return expdate; }
            set { expdate = value; }
        }

        private Boolean ispost ;
        public Boolean Ispost
        {
            get { return ispost; }
            set { ispost = value; }
        }

        private Boolean isprint;
        public Boolean Isprint
        {
            get { return isprint; }
            set { isprint = value; }
        }

        private int userid;
        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}

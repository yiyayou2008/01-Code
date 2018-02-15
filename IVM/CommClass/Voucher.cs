using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class Voucher
    {
        private string vouchernumber;
        public string VoucherNumber
        {
            get { return vouchernumber; }
            set { vouchernumber = value; }
        }

        private int companyid;
        public int CompanyId
        {
            get { return companyid; }
            set { companyid = value; }
        }

        private DateTime begindate;
        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }

        private DateTime enddate;
        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        private string vouchertype;
        public string VoucherType
        {
            get { return vouchertype; }
            set { vouchertype = value; }
        }

        private string isputinbox;
        public string IsPutInBox
        {
            get { return isputinbox; }
            set { isputinbox = value; }
        }
    }
}

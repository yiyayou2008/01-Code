using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class Invoice
    {
        private string invnumber;
        public string InvNumber
        {
            get { return invnumber; }
            set { invnumber = value; }
        }
        private int companyid;
        public int CompanyId
        {
            get { return companyid; }
            set { companyid = value; }
        }
        private string custname;
        public string Custname
        {
            get { return custname; }
            set { custname = value; }
        }

        private decimal amountNoTax;
        public decimal AmountNoTax
        {
            get { return amountNoTax; }
            set { amountNoTax = value; }
        }

        private decimal tax;
        public decimal Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        private bool ispost;
        public bool Ispost
        {
            get { return ispost; }
            set { ispost = value; }
        }

        private DateTime inputdate;
        public DateTime Inputdate
        {
            get { return inputdate; }
            set { inputdate = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class ExpAddress
    {
        private int expaddressid;
        public int ExpAddressId
        {
            get { return expaddressid; }
            set { expaddressid = value; }
        }

        private string customername;
        public string CustomerName
        {
            get { return customername; }
            set { customername = value; }
        }

        private string customersend;
        public string CustomerSend
        {
            get { return customersend; }
            set { customersend = value; }
        }

        private string custaddress;
        public string CustAddress
        {
            get { return custaddress; }
            set { custaddress = value; }
        }

        private string addressee;
        public string Addressee
        {
            get { return addressee; }
            set { addressee = value; }
        }

        private string custtel;
        public string CustTel
        {
            get { return custtel; }
            set { custtel = value; }
        }
    }
}

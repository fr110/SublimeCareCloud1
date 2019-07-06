using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhSaleMan
    {
        private long _iSaleManID;
        private string _vSaleManName;
        private string _vAddresss;
        private string _vMobile;
        public dhSaleMan()
        { }
        public long ISaleManID
        {
            get { return _iSaleManID; }
            set { _iSaleManID = value; }
        }

        public string VSaleManName
        {
            get { return _vSaleManName; }
            set { _vSaleManName = value; }
        }

        public string VAddresss
        {
            get { return _vAddresss; }
            set { _vAddresss = value; }
        }

        public string VMobile
        {
            get { return _vMobile; }
            set { _vMobile = value; }
        }

    }
}

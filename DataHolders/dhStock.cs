using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhStock
        //: INotifyPropertyChanged 
    {
        private long _iStokId;
        private System.Nullable<int> _iItemID;
        private System.Nullable<int> _iCurrantStock;
        private System.Nullable<int> _iUserId;
        private System.Nullable<int> _iStockIn;
        private System.Nullable<int> _iStockOut;
        private System.Nullable<int> _iSaleId;
        private System.Nullable<long> _iProductionId;
        private Boolean _IsAvailable ;
        private string _stockStatus;
        private string _vAction;

        public string VAction
        {
            get { return _vAction; }
            set { _vAction = value; }
        }

        private System.Nullable<System.DateTime> _dDate;

        public virtual System.Nullable<System.DateTime> DDate
        {
            get { return _dDate; }
            set { _dDate = value; }
        }
        private System.Nullable<System.DateTime> _dFromDate;

        public virtual System.Nullable<System.DateTime> DFromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value;  }
        }
        private System.Nullable<System.DateTime> _dToDate;

        public virtual System.Nullable<System.DateTime> DToDate
        {
            get { return _dToDate; }
            set { _dToDate = value;}
        }
        public virtual string StockStatus
        {
            get { return _stockStatus; }
            set { _stockStatus = value;
                //OnPropertyChanged("StockStatus");
            }
        }

        public virtual Boolean IsAvailable
        {
            get { return _IsAvailable; }
            set { _IsAvailable = value; }
        }

        public dhStock() { }

        public long IStokId
        {
            get { return _iStokId; }
            set { _iStokId = value; }
        }

        public  virtual System.Nullable<int> IItemID
        {
            get { return _iItemID; }
            set { _iItemID = value; }
        }

        public virtual System.Nullable<int> ICurrantStock
        {
            get { return _iCurrantStock; }
            set { _iCurrantStock = value;
               // OnPropertyChanged("ICurrantStock");
            }
        }

        public virtual System.Nullable<int> IStockIn
        {
            get { return _iStockIn; }
            set { _iStockIn = value; }
        }

        public virtual System.Nullable<int> IStockOut
        {
            get { return _iStockOut; }
            set { _iStockOut = value; }
        }

        public virtual System.Nullable<int> ISaleId
        {
            get { return _iSaleId; }
            set { _iSaleId = value; }
        }

        public virtual System.Nullable<long> IProductionId
        {
            get { return _iProductionId; }
            set { _iProductionId = value; }
        }

        public virtual System.Nullable<int> IUserId
        {
            get { return _iUserId; }
            set { _iUserId = value; }
        }

        //public virtual event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}

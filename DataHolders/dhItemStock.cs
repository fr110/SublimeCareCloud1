using System.ComponentModel;

namespace DataHolders
{
    public class dhItemStock : dhStock, INotifyPropertyChanged
    {
        private string _time;

        public string tTime
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged("tTime"); }
        }

        private System.Nullable<System.DateTime> _dFromDate;

        public System.Nullable<System.DateTime> DFromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; OnPropertyChanged("DFromDate"); }
        }

        private System.Nullable<System.DateTime> _dToDate;

        public System.Nullable<System.DateTime> DToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; OnPropertyChanged("DToDate"); }
        }

        private string _vItemName;
        private string _vDetailName;

        public string VItemName
        {
            get { return _vItemName; }
            set { _vItemName = value; OnPropertyChanged("VItemName"); }
        }

        public string VDetailName
        {
            get { return _vDetailName; }
            set { _vDetailName = value; OnPropertyChanged("VDetailName"); }
        }

        //public override string StockStatus
        //{
        //    get { return _stockStatus; }
        //    set { _stockStatus = value;
        //        //OnPropertyChanged("StockStatus");
        //    }
        //}

        //public override Boolean IsAvailable
        //{
        //    get { return _IsAvailable; }
        //    set { _IsAvailable = value; }
        //}

        //public dhStock() { IStockOut = 5; }

        //public long IStokId
        //{
        //    get { return _iStokId; }
        //    set { _iStokId = value; }
        //}
        private System.Nullable<int> _iItemID;

        public override System.Nullable<int> IItemID
        {
            get { return _iItemID; }
            set { _iItemID = value; }
        }

        //public override System.Nullable<int> ICurrantStock
        //{
        //    get { return _iCurrantStock; }
        //    set { _iCurrantStock = value;
        //       // OnPropertyChanged("ICurrantStock");
        //    }
        //}

        //public override System.Nullable<int> IStockIn
        //{
        //    get { return _iStockIn; }
        //    set { _iStockIn = value; }
        //}

        //public override System.Nullable<int> IStockOut
        //{
        //    get { return _iStockOut; }
        //    set { _iStockOut = value; }
        //}

        //public override System.Nullable<int> ISaleId
        //{
        //    get { return _iSaleId; }
        //    set { _iSaleId = value; }
        //}

        //public override System.Nullable<int> IProductionId
        //{
        //    get { return _iProductionId; }
        //    set { _iProductionId = value; }
        //}

        //public override System.Nullable<int> IUserId
        //{
        //    get { return _iUserId; }
        //    set { _iUserId = value; }
        //}

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
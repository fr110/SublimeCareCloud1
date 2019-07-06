using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhProduction : INotifyPropertyChanged
    {
        private System.Nullable<long> _iProductionId;
        private System.Nullable<System.DateTime> _dDate;
        private string _vLocation;
        private string _vPurchaseManager;
        private string _vProductionUnit;
        private System.Nullable<double> _fProductionCast;
        private System.Nullable<int> _iUpdate;
        private ItemsList _ItemsConsumed;
        private int iUserid;
        private Boolean _isReadOnly;
        private int _NumberOfItemConsumed;

        public dhProduction()
        {
             DDate = DateTime.Now;
        }

        public int NumberOfItemConsumed
        {
            get { return _NumberOfItemConsumed; }
            set { _NumberOfItemConsumed = value; OnPropertyChanged("NumberOfItemConsumed"); }
        }


        private int _NumberOfItemProduced;

        public int NumberOfItemProduced
        {
            get { return _NumberOfItemProduced; }
            set { _NumberOfItemProduced = value; OnPropertyChanged("NumberOfItemProduced"); }
        }

        public Boolean IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; OnPropertyChanged("IsReadOnly"); }
        } 
        public int IUserid
        {
            get { return iUserid; }
            set { iUserid = value; OnPropertyChanged("IUserid"); }
        }

        public ItemsList ItemsConsumed
        {
            get { return _ItemsConsumed; }
            set { _ItemsConsumed = value; OnPropertyChanged("ItemsConsumed"); }
        }
        private ItemsList _ItemsProduced;

        public ItemsList ItemsProduced
        {
            get { return _ItemsProduced; }
            set { _ItemsProduced = value; OnPropertyChanged("ItemsProduced"); }
        }

        public System.Nullable<long> IProductionId
        {
            get { return _iProductionId; }
            set { _iProductionId = value; OnPropertyChanged("IProductionId"); }
        }

        public System.Nullable<System.DateTime> DDate
        {
            get { return _dDate; }
            set { _dDate = value; OnPropertyChanged("DDate"); }
        }
              
        public string VLocation
        {
            get { return _vLocation; }
            set { _vLocation = value; OnPropertyChanged("VLocation"); }
        }

        public string VPurchaseManager
        {
            get { return _vPurchaseManager; }
            set { _vPurchaseManager = value; OnPropertyChanged("VPurchaseManager"); }
        }
 
        public string VProductionUnit
        {
            get { return _vProductionUnit; }
            set { _vProductionUnit = value; OnPropertyChanged("VProductionUnit"); }
        }

        public System.Nullable<double> FProductionCast
        {
            get { return _fProductionCast; }
            set { _fProductionCast = value; OnPropertyChanged("FProductionCast"); }
        }

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
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

    
    }
}

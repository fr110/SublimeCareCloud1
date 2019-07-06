using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhPreference : INotifyPropertyChanged
    {
        private int _iCompanyID;
        private System.Nullable<bool> _bShowStockStatus;

        public System.Nullable<bool> BShowStockStatus
        {
            get { return _bShowStockStatus; }
            set { _bShowStockStatus = value; OnPropertyChanged("BShowStockStatus"); }
        }


        private System.Nullable<bool> _bShowPartyDetail;

        public System.Nullable<bool> BShowPartyDetail
        {
            get { return _bShowPartyDetail; }
            set { _bShowPartyDetail = value; OnPropertyChanged("BShowPartyDetail"); }
        }
        private System.Nullable<bool> _bShowDeliveryDetail;

        public System.Nullable<bool> BShowDeliveryDetail
        {
            get { return _bShowDeliveryDetail; }
            set { _bShowDeliveryDetail = value; OnPropertyChanged("BShowDeliveryDetail"); }
        }

        private System.Nullable<bool> _bDurationReturnOnly;

        public System.Nullable<bool> BDurationReturnOnly
        {
            get { return _bDurationReturnOnly; }
            set { _bDurationReturnOnly = value; OnPropertyChanged("BDurationReturnOnly"); }
        }
        private System.Nullable<int> _iAllowedBackDays;

        public System.Nullable<int> IAllowedBackDays
        {
            get { return _iAllowedBackDays; }
            set { _iAllowedBackDays = value; OnPropertyChanged("IAllowedBackDays"); }
        }
        public int ICompanyID
        {
            get { return _iCompanyID; }
            set { _iCompanyID = value; OnPropertyChanged("ICompanyID"); }
        }

        private System.Data.Linq.Binary _imLogoImage;

        public System.Data.Linq.Binary ImLogoImage
        {
            get { return _imLogoImage; }
            set { _imLogoImage = value; OnPropertyChanged("ImLogoImage"); }
        }

        private string _vHeaderText;

        public string VHeaderText
        {
            get { return _vHeaderText; }
            set { _vHeaderText = value; OnPropertyChanged("VHeaderText"); }
        }

        private System.Nullable<bool> _bIsActive;

        public System.Nullable<bool> BIsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; OnPropertyChanged("BIsActive"); }
        }

        private string _vDateFormat;

        public string VDateFormat
        {
            get { return _vDateFormat; }
            set { _vDateFormat = value; OnPropertyChanged("VDateFormat"); }
        }

        private System.Nullable<bool> _bStockOverRide;

        public System.Nullable<bool> BStockOverRide
        {
            get { return _bStockOverRide; }
            set { _bStockOverRide = value; OnPropertyChanged("BStockOverRide"); }
        }

        private string _vSaleType;

        public string VSaleType
        {
            get { return _vSaleType; }
            set { _vSaleType = value; OnPropertyChanged("VSaleType"); }
        }

        private System.Nullable<bool> _bDefaultCustomer;

        public System.Nullable<bool> BDefaultCustomer
        {
            get { return _bDefaultCustomer; }
            set { _bDefaultCustomer = value; OnPropertyChanged("BDefaultCustomer"); }
        }
        private int _iUpdate;
        private int _iSalaryDays;

        public int ISalaryDays
        {
            get { return _iSalaryDays; }
            set { _iSalaryDays = value; OnPropertyChanged("ISalaryDays"); }
        }
        
        public int IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        private System.Nullable<int> _bCashierID;

        public System.Nullable<int> BCashierID
        {
            get { return _bCashierID; }
            set { _bCashierID = value; OnPropertyChanged("BCashierID"); }
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
    }
}


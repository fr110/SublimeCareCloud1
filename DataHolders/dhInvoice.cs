using System;
using System.ComponentModel;

namespace DataHolders
{
    public class dhInvoice : INotifyPropertyChanged
    {
        private System.Nullable<long> _iSaleid;
        private System.Nullable<long> _ipartyId;
        private System.Nullable<System.DateTime> _ddate;
        private string _vpartyName;
        private string _vpartymobile;
        private System.Nullable<double> _ftotalamount;
        private string _vPaymentMod;
        private string _vVehicleNo;
        private string _vDriverName;
        private System.Nullable<long> _iUserid;
        private string _vDeliveryExpense;
        private string _vSeason;
        private System.Nullable<int> _iDiscountPersent;
        private System.Nullable<double> _fPayAbleAmount;
        private System.Nullable<double> _fAmmountRecived;
        private string _vReciverName;
        private System.Nullable<long> _iSaleManID;
        private System.Nullable<double> _fBalance;
        private System.Nullable<int> _iUpdate;
        private System.Nullable<double> _amountwithDExpense;
        private ItemsList _ItemsOfInvoice;
        private string _vpartyAddress;
        private System.Nullable<Boolean> _IsReadOnly;
        private System.Nullable<System.DateTime> _dFromDate;
        private System.Nullable<int> _liftnumber;
        private System.Nullable<double> _fServices;
        private System.Nullable<double> _fGrossPurchasePrice;

        public System.Nullable<double> FGrossPurchasePrice
        {
            get { return _fGrossPurchasePrice; }
            set { _fGrossPurchasePrice = value; OnPropertyChanged("FGrossPurchasePrice"); }
        }

        public System.Nullable<double> FServices
        {
            get { return _fServices; }
            set { _fServices = value; OnPropertyChanged("FServices"); }
        }

        private string _vFirstElectricianName;

        public string VFirstElectricianName
        {
            get { return _vFirstElectricianName; }
            set { _vFirstElectricianName = value; OnPropertyChanged("VFirstElectricianName"); }
        }

        private string _vSecElectricianName;

        public string VSecElectricianName
        {
            get { return _vSecElectricianName; }
            set { _vSecElectricianName = value; OnPropertyChanged("VSecElectricianName"); }
        }

        public System.Nullable<int> LiftNumber
        {
            get { return _liftnumber; }
            set { _liftnumber = value; OnPropertyChanged("Liftnumber"); }
        }

        private System.Nullable<Boolean> _bIsDraft;

        public System.Nullable<Boolean> BIsDraft
        {
            get { return _bIsDraft; }
            set { _bIsDraft = value; OnPropertyChanged("BIsDraft"); }
        }

        private System.Nullable<Boolean> _bFinalized;

        public System.Nullable<Boolean> BFinalized
        {
            get { return _bFinalized; }
            set { _bFinalized = value; OnPropertyChanged("BFinalized"); }
        }

        private System.Nullable<bool> _bCanelDone;

        public System.Nullable<bool> BCanelDone
        {
            get { return _bCanelDone; }
            set { _bCanelDone = value; OnPropertyChanged("BCanelDone"); }
        }

        private System.Nullable<bool> _bReturnInvoice;

        public System.Nullable<bool> BReturnInvoice
        {
            get { return _bReturnInvoice; }
            set { _bReturnInvoice = value; OnPropertyChanged("BReturnInvoice"); }
        }

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

        public System.Nullable<Boolean> IsReadOnly
        {
            get { return _IsReadOnly; }
            set { _IsReadOnly = value; OnPropertyChanged("IsReadOnly"); }
        }

        public string VpartyAddress
        {
            get { return _vpartyAddress; }
            set { _vpartyAddress = value; OnPropertyChanged("VpartyAddress"); }
        }

        public ItemsList ItemsOfInvoice
        {
            get { return _ItemsOfInvoice; }
            set { _ItemsOfInvoice = value; OnPropertyChanged("ItemsOfInvoice"); }
        }

        public dhInvoice()
        {
            //  IUpdate = 0;
            //  IDiscountPersent = 1;
            Ddate = DateTime.Now;
        }

        public dhInvoice(dhUsers objCurrentUser)
        {
            //   IUpdate = 0;
            //  IDiscountPersent = 1;
            IUserid = objCurrentUser.IUserid;
            Ddate = DateTime.Now;
        }

        public System.Nullable<long> ISaleid
        {
            get { return _iSaleid; }
            set { _iSaleid = value; OnPropertyChanged("ISaleid"); }
        }

        public System.Nullable<long> IpartyId
        {
            get { return _ipartyId; }
            set
            {
                _ipartyId = value;
                OnPropertyChanged("IpartyId");
            }
        }

        public System.Nullable<System.DateTime> Ddate
        {
            get { return _ddate; }
            set
            {
                _ddate = value;
                OnPropertyChanged("Ddate");
            }
        }

        public string VpartyName
        {
            get { return _vpartyName; }
            set
            {
                _vpartyName = value;
                OnPropertyChanged("VpartyName");
            }
        }

        public string Vpartymobile
        {
            get { return _vpartymobile; }
            set
            {
                _vpartymobile = value;
                OnPropertyChanged("Vpartymobile");
            }
        }

        public System.Nullable<double> Ftotalamount
        {
            get { return _ftotalamount; }
            set
            {
                _ftotalamount = value;
                OnPropertyChanged("Ftotalamount");
            }
        }

        public string VPaymentMod
        {
            get { return _vPaymentMod; }
            set
            {
                _vPaymentMod = value;
                OnPropertyChanged("VPaymentMod");
            }
        }

        public string VVehicleNo
        {
            get { return _vVehicleNo; }
            set
            {
                _vVehicleNo = value;
                OnPropertyChanged("VVehicleNo");
            }
        }

        public string VDriverName
        {
            get { return _vDriverName; }
            set
            {
                _vDriverName = value;
                OnPropertyChanged("VDriverName");
            }
        }

        public System.Nullable<long> IUserid
        {
            get { return _iUserid; }
            set
            {
                _iUserid = value;
                OnPropertyChanged("IUserid");
            }
        }

        public string VDeliveryExpense
        {
            get { return _vDeliveryExpense; }
            set
            {
                _vDeliveryExpense = value;
                OnPropertyChanged("VDeliveryExpense");
            }
        }

        public string VSeason
        {
            get { return _vSeason; }
            set
            {
                _vSeason = value;
                OnPropertyChanged("VSeason");
            }
        }

        public System.Nullable<int> IDiscountPersent
        {
            get { return _iDiscountPersent; }
            set
            {
                _iDiscountPersent = value;
                OnPropertyChanged("IDiscountPersent");
            }
        }

        public System.Nullable<double> FPayAbleAmount
        {
            get { return _fPayAbleAmount; }
            set
            {
                _fPayAbleAmount = value;
                OnPropertyChanged("FPayAbleAmount");
            }
        }

        public System.Nullable<double> FAmmountRecived
        {
            get { return _fAmmountRecived; }
            set
            {
                _fAmmountRecived = value;
                OnPropertyChanged("FAmmountRecived");
            }
        }

        public string VReciverName
        {
            get { return _vReciverName; }
            set
            {
                _vReciverName = value;
                OnPropertyChanged("VReciverName");
            }
        }

        public System.Nullable<long> ISaleManID
        {
            get { return _iSaleManID; }
            set
            {
                _iSaleManID = value;
                OnPropertyChanged("ISaleManID");
            }
        }

        public System.Nullable<double> FBalance
        {
            get { return _fBalance; }
            set
            {
                _fBalance = value;
                OnPropertyChanged("FBalance");
            }
        }

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        public System.Nullable<double> AmountwithDExpense
        {
            get { return _amountwithDExpense; }
            set { _amountwithDExpense = value; OnPropertyChanged("AmountwithDExpense"); }
        }

        private long _CostumerID;

        public long ICostumerId
        {
            get { return _CostumerID; }
            set { _CostumerID = value; OnPropertyChanged("ICostumerId"); }
        }

        private string _CostumerName;

        public string CostumerName
        {
            get { return _CostumerName; }
            set { _CostumerName = value; OnPropertyChanged("CostumerName"); }
        }

        private string _CostumerBikeNumber;

        public string CostumerBikeNumber
        {
            get { return _CostumerBikeNumber; }
            set { _CostumerBikeNumber = value; OnPropertyChanged("CostumerBikeNumber"); }
        }

        private string _CostumerMobileNumber;

        public string CostumerMobileNumber
        {
            get { return _CostumerMobileNumber; }
            set { _CostumerMobileNumber = value; OnPropertyChanged("CostumerMobileNumber"); }
        }

        private System.Nullable<System.DateTime> _CostumerLastVisit;

        public System.Nullable<System.DateTime> CostumerLastVisit
        {
            get { return _CostumerLastVisit; }
            set { _CostumerLastVisit = value; OnPropertyChanged("CostumerLastVisit"); }
        }

        private string _CostumerInfo;

        public string CostumerInfo
        {
            get { return _CostumerInfo; }
            set { _CostumerInfo = value; OnPropertyChanged("CostumerLastVisit"); }
        }

        private string _MeterReading;

        public string MeterReading
        {
            get { return _MeterReading; }
            set { _MeterReading = value; OnPropertyChanged("CostumerLastVisit"); }
        }

        private string _ModelNumber;

        public string ModelNumber
        {
            get { return _ModelNumber; }
            set { _ModelNumber = value; OnPropertyChanged("CostumerLastVisit"); }
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
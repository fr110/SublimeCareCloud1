using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
   public  class dhPurchase: INotifyPropertyChanged
    {
        private System.Nullable<long> _iPurchaseid;
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
        private System.Nullable<long> _iPurchaseManID;
        private System.Nullable<double> _fBalance;
        private System.Nullable<int> _iUpdate;
        private System.Nullable<double> _amountwithDExpense;
        private ItemsList _ItemsOfPurchase;
        private string _vpartyAddress;
        private System.Nullable<Boolean> _IsReadOnly;
        private System.Nullable<System.DateTime> _dFromDate;
        private System.Nullable<System.DateTime> _dToDate;

        private string _formnumber;

        public string Formnumber
        {
            get { return _formnumber; }
            set { _formnumber = value; OnPropertyChanged("Formnumber"); }
        }

        public System.Nullable<System.DateTime> DFromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; OnPropertyChanged("DFromDate"); }
        }
       

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


        public ItemsList ItemsOfPurchase
        {
            get { return _ItemsOfPurchase; }
            set { _ItemsOfPurchase = value; OnPropertyChanged("ItemsOfPurchase"); }
        }

        public dhPurchase()
        {
            //  IUpdate = 0;
            //  IDiscountPersent = 1;
            Ddate = DateTime.Now;
        }
        public dhPurchase(dhUsers objCurrentUser)
        {
            //   IUpdate = 0;
            //  IDiscountPersent = 1;
            IUserid = objCurrentUser.IUserid;
            Ddate = DateTime.Now;
        }

        public System.Nullable<long> IPurchaseid
        {
            get { return _iPurchaseid; }
            set { _iPurchaseid = value; OnPropertyChanged("IPurchaseid"); }
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


        public System.Nullable<long> IPurchaseManID
        {
            get { return _iPurchaseManID; }
            set
            {
                _iPurchaseManID = value;
                OnPropertyChanged("IPurchaseManID");
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

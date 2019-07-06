using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;

namespace DataHolders
{
    public class dhSaleItem : dhStock, INotifyPropertyChanged
    {
        private int _iSaleItemid;
        private long _iSaleid;
        private System.Nullable<double> _fUnitePrice;
        private System.Nullable<int> _iQuantity;
        private System.Nullable<double> _fGrossAmount;
        private System.Nullable<int> _iItemID;
        private string _vItemName;
        private System.Nullable<int> _iUpdate;
        private System.Nullable<int> _iSerialNumber;
        private System.Nullable<int> _iUserId;
        private long _iPurchaseItemid;
        private System.Nullable<long> _iPurchaseid;
        private System.Nullable<long> _iProductionid;
        private System.Nullable<System.DateTime> _dDate;
        private System.Nullable<double> _fGrossPurchasePrice;

        public System.Nullable<double> FGrossPurchasePrice
        {
            get { return _fGrossPurchasePrice; }
            set { _fGrossPurchasePrice = value; OnPropertyChanged("FGrossPurchasePrice"); }
        }

        private System.Nullable<double> _fUnitPurchasePrice;

        public System.Nullable<double> FUnitPurchasePrice
        {
            get { return _fUnitPurchasePrice; }
            set { _fUnitPurchasePrice = value; OnPropertyChanged("FUnitPurchasePrice"); }
        }

        private System.Nullable<Boolean> _bIsDraft;

        public System.Nullable<Boolean> BIsDraft
        {
            get { return _bIsDraft; }
            set { _bIsDraft = value; OnPropertyChanged("BIsDraft"); }
        }
        
        public override System.Nullable<System.DateTime> DDate
        {
            get { return _dDate; }
            set { _dDate = value; OnPropertyChanged("DDate"); }
        }
        public override System.Nullable<long> IProductionId
        {
            get { return _iProductionid; }
            set { _iProductionid = value; OnPropertyChanged("IProductionId"); }
        }
        private System.Nullable<int> _iProductionItemid;

        public System.Nullable<int> IProductionItemid
        {
            get { return _iProductionItemid; }
            set { _iProductionItemid = value; OnPropertyChanged("IProductionItemid"); }
        }

        public long IPurchaseItemid
        {
            get { return _iPurchaseItemid; }
            set { _iPurchaseItemid = value; OnPropertyChanged("IPurchaseItemid"); }
        }
        public System.Nullable<long> IPurchaseid
        {
            get { return _iPurchaseid; }
            set { _iPurchaseid = value; OnPropertyChanged("IPurchaseid"); }
        }


        public override System.Nullable<int> IUserId
        {
            get { return _iUserId; }
            set { _iUserId = value; }
        }

        public System.Nullable<int> ISerialNumber
        {
            get { return _iSerialNumber; }
            set { _iSerialNumber = value;  
            OnPropertyChanged("ISerialNumber");}
        }

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; }
        }
        public string VItemName
        {
            get { return _vItemName; }
            set { _vItemName = value; OnPropertyChanged("VItemName"); }
        }
        public dhSaleItem()
        {
            //FUnitePrice = 10;
            //IQuantity = 5;
        }

        public int ISaleItemid
        {
            get { return _iSaleItemid; }
            set { _iSaleItemid = value; OnPropertyChanged("ISaleItemid"); }
        }

        
        public long ISaleid
        {
            get { return _iSaleid; }
            set { _iSaleid = value; OnPropertyChanged("ISaleid"); }
        }

        
        public System.Nullable<double> FUnitePrice
        {
            get { return _fUnitePrice; }
            set { _fUnitePrice = value;
            OnPropertyChanged("FUnitePrice");
            }
        }

        
        public System.Nullable<int> IQuantity
        {
            get { return _iQuantity; }
            set { _iQuantity = value; OnPropertyChanged("IQuantity");
            Int32 q;
            Int32.TryParse(IQuantity.ToString(), out q);
            double funitprice;
            double.TryParse(FUnitePrice.ToString(), out funitprice);
            FGrossAmount = (q * funitprice);
           // double funitpriceGross;
            //double.TryParse(FUnitPurchasePrice.ToString(), out funitpriceGross);
            //FGrossPurchasePrice = (q * funitpriceGross);
            }
        }

        
        public System.Nullable<double> FGrossAmount
        {
            get { return _fGrossAmount; }
            set { _fGrossAmount = value; OnPropertyChanged("FGrossAmount"); }
        }

        

        public System.Nullable<int> IItemID
        {
            get { return _iItemID; }
            set { _iItemID = value; OnPropertyChanged("IItemID"); }
        }

        public  event PropertyChangedEventHandler PropertyChanged;
        protected  void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }





   //     private System.Nullable<int> _iItemID;
   //     private string _vItemName;
        private string _vDetailName;
        private System.Nullable<bool> _bFuzzyDelented;
        private string _vCompanyName;
  //      private System.Nullable<double> _fUnitePrice;
        private System.Nullable<double> _fMaxDiscountPresent;
        private string _vItemBarcode;
   //     private System.Nullable<int> _iQuantity;
        private System.Nullable<double> _ammount;

        public System.Nullable<double> Ammount
        {
            get { return _ammount; }
            set
            {
                _ammount = value;
                OnPropertyChanged("Ammount");
            }
        }

        //public override System.Nullable<int> IItemID
        //{
        //    get { return _iItemID; }
        //    set
        //    {
        //        _iItemID = value;
        //        OnPropertyChanged("IItemID");
        //    }
        //}

        //public string VItemName
        //{
        //    get { return _vItemName; }
        //    set { _vItemName = value; OnPropertyChanged("VItemName"); }
        //}

        public string VDetailName
        {
            get { return _vDetailName; }
            set { _vDetailName = value; OnPropertyChanged("VDetailName"); }
        }

        public System.Nullable<bool> BFuzzyDelented
        {
            get { return _bFuzzyDelented; }
            set { _bFuzzyDelented = value; OnPropertyChanged("BFuzzyDelented"); }
        }

        public string VCompanyName
        {
            get { return _vCompanyName; }
            set { _vCompanyName = value; OnPropertyChanged("VCompanyName"); }
        }

        //public System.Nullable<double> FUnitePrice
        //{
        //    get { return _fUnitePrice; }
        //    set
        //    {
        //        _fUnitePrice = value;
        //        OnPropertyChanged("FUnitePrice");
        //    }
        //}

        public System.Nullable<double> FMaxDiscountPresent
        {
            get { return _fMaxDiscountPresent; }
            set { _fMaxDiscountPresent = value; OnPropertyChanged("FMaxDiscountPresent"); }
        }


        public string VItemBarcode
        {
            get { return _vItemBarcode; }
            set { _vItemBarcode = value; OnPropertyChanged("VItemBarcode"); }
        }

        private string _BIsEditAbleInInvoice;

        public string BIsEditAbleInInvoice
        {
            get { return _BIsEditAbleInInvoice; }
            set { _BIsEditAbleInInvoice = value; OnPropertyChanged("BIsEditAbleInInvoice"); }
        }
        //public System.Nullable<int> IQuantity
        //{
        //    get { return _iQuantity; }
        //    set
        //    {
        //        _iQuantity = value;
        //        OnPropertyChanged("IQuantity"); //OnPropertyChanged("Ammount"); 

        //    }
        //}
    }
}

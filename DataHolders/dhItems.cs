using System;
using System.ComponentModel;
using System.Linq;

namespace DataHolders
{
    public class dhItems : dhStock, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly dhItemsValidator _dhItemsValidator;

        public dhItems()
        {
            this._dhItemsValidator = new dhItemsValidator();
            IUpdate = 0;
        }

        //public dhItems()
        //{
        //    //FUnitePrice = 10;
        //    //IQuantity = 1;
        //    IUpdate = 0;
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _dhItemsValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                //this.CanSave = null;
                if (firstOrDefault != null)
                {
                    this.CanSave = false;
                    OnPropertyChanged("CanSave");
                    return firstOrDefault.ErrorMessage;
                }
                else
                {
                    this.CanSave = true;
                    OnPropertyChanged("CanSave");
                    return "";
                }
                // return _dhPartyValidator != null ? firstOrDefault.ErrorMessage : CanSave = String.Empty;

                //return "";
            }
        }

        public string Error
        {
            get
            {
                if (_dhItemsValidator != null)
                {
                    var results = _dhItemsValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        private bool canSave;

        public bool CanSave
        {
            get { return canSave; }
            set { canSave = value; OnPropertyChanged("CanSave"); }
        }

        private System.Nullable<int> _sr;

        public System.Nullable<int> SR
        {
            get { return _sr; }
            set { _sr = value; }
        }

        private System.Nullable<int> _iItemID;
        private string _vItemName;
        private string _vDetailName;
        private System.Nullable<bool> _bFuzzyDelented;
        private string _vCompanyName;
        private System.Nullable<double> _fUnitePrice;
        private System.Nullable<double> _fMaxDiscountPresent;
        private string _vItemBarcode;
        private System.Nullable<int> _iQuantity;
        private System.Nullable<double> _ammount;
        private System.Nullable<int> _iUpdate;
        private System.Nullable<bool> _bIsSaleAble;
        private string _vPackDescription;
        private System.Nullable<int> _initialStock;
        private System.Nullable<int> _iAlertAmount;
        private System.Nullable<bool> _bAllowPrint;

        public System.Nullable<bool> BAllowPrint
        {
            get { return _bAllowPrint; }
            set { _bAllowPrint = value; }
        }

        public System.Nullable<int> IAlertAmount
        {
            get { return _iAlertAmount; }
            set { _iAlertAmount = value; }
        }

        public System.Nullable<int> InitialStock
        {
            get { return _initialStock; }
            set { _initialStock = value; }
        }

        private System.Nullable<double> _fUnitPurchasePrice;

        public System.Nullable<double> FUnitPurchasePrice
        {
            get { return _fUnitPurchasePrice; }
            set { _fUnitPurchasePrice = value; OnPropertyChanged("FUnitPurchasePrice"); }
        }

        private string _vItemType;

        public string VItemType
        {
            get { return _vItemType; }
            set { _vItemType = value; }
        }

        public string VPackDescription
        {
            get { return _vPackDescription; }
            set { _vPackDescription = value; OnPropertyChanged("VPackDescription"); }
        }

        public System.Nullable<bool> BIsSaleAble
        {
            get { return _bIsSaleAble; }
            set { _bIsSaleAble = value; OnPropertyChanged("BIsSaleAble"); }
        }

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        public System.Nullable<double> Ammount
        {
            get { return _ammount; }
            set
            {
                _ammount = value;
                OnPropertyChanged("Ammount");
            }
        }

        public override System.Nullable<int> IItemID
        {
            get { return _iItemID; }
            set
            {
                _iItemID = value;
                OnPropertyChanged("IItemID");
            }
        }

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

        public System.Nullable<double> FUnitePrice
        {
            get { return _fUnitePrice; }
            set
            {
                _fUnitePrice = value;
                OnPropertyChanged("FUnitePrice");
            }
        }

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

        public System.Nullable<int> IQuantity
        {
            get { return _iQuantity; }
            set
            {
                _iQuantity = value;
                OnPropertyChanged("IQuantity"); //OnPropertyChanged("Ammount");
            }
        }

        private Boolean _bIsEditAbleInInvoice;

        public Boolean BIsEditAbleInInvoice
        {
            get { return _bIsEditAbleInInvoice; }
            set { _bIsEditAbleInInvoice = value; OnPropertyChanged("BIsEditAbleInInvoice"); }
        }

        private string _BIsEditAbleInInvoice2;

        public string BIsEditAbleInInvoice2
        {
            get { return _BIsEditAbleInInvoice2; }
            set { _BIsEditAbleInInvoice2 = value; OnPropertyChanged("BIsEditAbleInInvoice2"); }
        }
    }
}
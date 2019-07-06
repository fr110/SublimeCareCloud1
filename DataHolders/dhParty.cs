using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhParty : INotifyPropertyChanged, IDataErrorInfo
    {
        
        private readonly dhPartyValidator _dhPartyValidator;
        public dhParty()
        {
            this._dhPartyValidator = new dhPartyValidator();
            IUpdate = 0;
        }

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
                var firstOrDefault = _dhPartyValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                //this.CanSave = null;
                if (firstOrDefault != null)
                {
                    this.CanSave = false;
                    OnPropertyChanged("CanSave");
                    return firstOrDefault.ErrorMessage;
                }else
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
                if (_dhPartyValidator != null)
                {
                    var results = _dhPartyValidator.Validate(this);
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


        private System.Nullable<long> _iPartyID;
        private string _vPartyName;
        private string _vPartyadress;
        private string _vpartyMobile;
        private System.Nullable<int> _iSaleManID;
        private string _vPartyInfo;
        private System.Nullable<int> _iUpdate;
        private System.Nullable<long> _iCreditLimit;

        
        private string _vMarket;
        private string _vArea;
        private string _vDistrict;
        private string _VCity;

        private string _vContactPerson;
        private string _vLandlineNumber;

        

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        public string VPartyInfo
        {
            get { return _vPartyInfo; }
            set { _vPartyInfo = value; OnPropertyChanged("VPartyInfo"); }
        }
        //public dhParty()

        //{
        //  IUpdate = 0;
        ////    VPartyName = "Test";
        //}
        public System.Nullable<long> IPartyID
        {
            get { return _iPartyID; }
            set { _iPartyID = value; OnPropertyChanged("IPartyID"); }
        }

        public string VPartyName
        {
            get { return _vPartyName; }
            set {

                _vPartyName = value;

                OnPropertyChanged("VPartyName"); }
        }

        public string VPartyadress
        {
            get { return _vPartyadress; }
            set { _vPartyadress = value; OnPropertyChanged("VPartyadress"); }
        }

        public string VpartyMobile
        {
            get { return _vpartyMobile; }
            set { _vpartyMobile = value; OnPropertyChanged("VpartyMobile"); }
        }


        public System.Nullable<int> ISaleManID
        {
            get { return _iSaleManID; }
            set { _iSaleManID = value; 
                  OnPropertyChanged("ISaleManID"); 
                }
        }

        public string VMarket
        {
            get { return _vMarket; }
            set
            {
                _vMarket = value; OnPropertyChanged("VMarket");
            }
        }
        public string VArea
        {
            get { return _vArea; }
            set
            {
                _vArea = value; OnPropertyChanged("VArea");
            }
        }
        public string VDistrict
        {
            get { return _vDistrict; }
            set
            {
                _vDistrict = value; OnPropertyChanged("VDistrict");
            }
        }
        public string VCity
        {
            get { return _VCity; }
            set
            {
                _VCity = value; OnPropertyChanged("VCity");
            }
        }
        public string VContactPerson
        {
            get { return _vContactPerson; }
            set { _vContactPerson = value; OnPropertyChanged("VContactPerson"); }
        }



        public string VLandlineNumber
        {
            get { return _vLandlineNumber; }
            set { _vLandlineNumber = value; OnPropertyChanged("VLandlineNumber"); }
        }
        public System.Nullable<long> ICreditLimit
        {
            get { return _iCreditLimit; }
            set { _iCreditLimit = value; OnPropertyChanged("ICreditLimit"); }
        }

     
    }
}

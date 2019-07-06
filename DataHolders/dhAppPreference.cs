using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhAppPreference : INotifyPropertyChanged
    {
        private int _iUpdate;

        public int IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; }
        }
        private int _iApplicationID;

        public int IApplicationID
        {
            get { return _iApplicationID; }
            set { _iApplicationID = value; OnPropertyChanged("IApplicationID"); }
        }

        private string _vPID;

        public string VPID
        {
            get { return _vPID; }
            set { _vPID = value; OnPropertyChanged("VPID"); }
        }
        private string _vApplicationName;

        public string VApplicationName
        {
            get { return _vApplicationName; }
            set { _vApplicationName = value; OnPropertyChanged("VApplicationName"); }
        }

        private System.Byte[] _imgCompanyLogo;

        public System.Byte[] ImgCompanyLogo
        {
            get { return _imgCompanyLogo; }
            set { _imgCompanyLogo = value; OnPropertyChanged("ImgCompanyLogo"); }
        }

        private string _vCompanyName;

        public string VCompanyName
        {
            get { return _vCompanyName; }
            set { _vCompanyName = value; OnPropertyChanged("VCompanyName"); }
        }
        private string _vEnableModules;

        public string VEnableModules
        {
            get { return _vEnableModules; }
            set { _vEnableModules = value; OnPropertyChanged("VEnableModules"); }
        }

        private string _vHeaderAdress;

        public string VHeaderAdress
        {
            get { return _vHeaderAdress; }
            set { _vHeaderAdress = value; OnPropertyChanged("VHeaderAdress"); }
        }


        private string _vCompanyMobile;

        public string VCompanyMobile
        {
            get { return _vCompanyMobile; }
            set { _vCompanyMobile = value; OnPropertyChanged("VCompanyMobile"); }
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
      

     //  public event PropertyChangedEventHandler PropertyChanged;
    }
}

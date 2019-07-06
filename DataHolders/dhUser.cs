
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataHolders
{
    public class dhUsers: INotifyPropertyChanged
    {
        private int iUserid;
        [Key]
        public int IUserid
        {
            get { return iUserid; }
            set { iUserid = value; OnPropertyChanged("IUserid"); }
        }

        private string _vAllowdModule;

        public string VAllowdModule
        {
            get { return _vAllowdModule; }
            set { _vAllowdModule = value; OnPropertyChanged("VAllowdModule"); }
        }
        private string _vfName;

        public string VfName
        {
            get { return _vfName; }
            set { _vfName = value; OnPropertyChanged("VfName"); }
        }

        private string _vlName;

        public string VlName
        {
            get { return _vlName; }
            set { _vlName = value; OnPropertyChanged("VlName"); }
        }

        private System.Nullable<System.DateTime> _dDOB;

        public System.Nullable<System.DateTime> DDOB
        {
            get { return _dDOB; }
            set { _dDOB = value; OnPropertyChanged("DDOB"); }
        }

        private string _vUserType;

        public string VUserType
        {
            get { return _vUserType; }
            set { _vUserType = value; OnPropertyChanged("VUserType"); }
        }

        private string _vLogin;

        public string VLogin
        {
            get { return _vLogin; }
            set
            {
                _vLogin = value;  OnPropertyChanged("VLogin");
            }
        }

        private string _vPassword;
        private string _vcPassword;

        public string VcPassword
        {
            get { return _vcPassword; }
            set { _vcPassword = value;

            OnPropertyChanged("VcPassword");
            }
        }
        
        public string VPassword
        {
            get { return _vPassword; }
            set
            {
                _vPassword = value;  OnPropertyChanged("VPassword");
            }
        }

        private System.Nullable<System.DateTime> _dLastLoginTime;

        public System.Nullable<System.DateTime> DLastLoginTime
        {
            get { return _dLastLoginTime; }
            set { _dLastLoginTime = value; OnPropertyChanged("DLastLoginTime"); }
        }

        private string _vEmail;

        public string VEmail
        {
            get { return _vEmail; }
            set { _vEmail = value; OnPropertyChanged("VEmail"); }
        }

        private Boolean bLoginStatus;

        public Boolean BLoginStatus
        {
            get { return bLoginStatus; }
            set { bLoginStatus = value; OnPropertyChanged("VEmail"); }
        }
        private DateTime? dLastLoginTime;

        public DateTime? DLastLoginTime1
        {
            get { return dLastLoginTime; }
            set { dLastLoginTime = value; OnPropertyChanged("VEmail"); }
        }
        private int iUpdate;
        private string vGeneralQuery;
        private string _temp_oldpass;
        private string _temp_newpass;

        private System.Nullable<bool> _bIsActive;

        public System.Nullable<bool> BIsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; OnPropertyChanged("BIsActive"); }
        }

        public dhUsers()
        {

        }

        //public int IUserid
        //{
        //    set { iUserid = value; OnPropertyChanged("IUserid"); }
        //    get { return iUserid; }
        //}

        //public string Password
        //{
        //    set
        //    {
        //        vPassword = value;
        //        if (String.IsNullOrEmpty(vPassword))
        //        {
        //            throw new ApplicationException("Please Enter Password.");

        //        }  OnPropertyChanged("Password");
                

        //    }
        //    get { return vPassword; }
        //}

        //public string Login
        //{
        //    set {vLogin = value;
        //            if (String.IsNullOrEmpty(vLogin))
        //            {
        //                throw new ApplicationException("Please Enter User Name.");
        //            }  OnPropertyChanged("Login");
        //    }
        //    get { return vLogin; }
           
        //}

        //public string fName
        //{
        //    set { vfName = value; OnPropertyChanged("fName"); }
        //    get { return vfName; }
        //}

        //public string lName
        //{
        //    set { vlName = value; OnPropertyChanged("lName"); }
        //    get { return vlName; }
        //}

        //public string UserType
        //{
        //    set { vUserType = value; OnPropertyChanged("UserType"); }
        //    get { return vUserType; }
        //}

        //public DateTime? DOB
        //{
        //    set { dDOB = value; OnPropertyChanged("DOB"); }
        //    get { return dDOB; }
        //}

        public DateTime? LastLoginTime
        {
            set { dLastLoginTime = value; OnPropertyChanged("LastLoginTime"); }
            get { return dLastLoginTime; }
        }

        public Boolean LoginStatus
        {
            set { bLoginStatus = value; OnPropertyChanged("LoginStatus"); }
            get { return bLoginStatus; }
        }

        public int IUpdate
        {
            set { iUpdate = value; OnPropertyChanged("IUpdate"); }
            get { return iUpdate; }
        }

        public string GeneralQuery
        {
            set { vGeneralQuery = value; OnPropertyChanged("GeneralQuery"); }
            get { return vGeneralQuery; }
        }

        public string temp_oldpass
        {
            set { _temp_oldpass = value; OnPropertyChanged("temp_oldpass"); }
            get { return _temp_oldpass; }
        }

        public string temp_newpass
        {
            set { _temp_newpass = value; OnPropertyChanged("temp_newpass"); }
            get { return _temp_newpass;  }
        }

        private Boolean _bCanMakeEditAble;

        public Boolean BCanMakeEditAble
        {
            get { return _bCanMakeEditAble; }
            set { _bCanMakeEditAble = value; OnPropertyChanged("BCanMakeEditAble"); }
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

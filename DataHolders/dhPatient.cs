using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    [Table("scc_Patients")]
    public class dhPatient : INotifyPropertyChanged
    {
        private long _iPatid;
        private string _vFullName;
        private System.Nullable<System.DateTime> dDOB;
        private string _vEmail;
        private string _vFatherName;
        private string _vGender;
        private Boolean _bActive = true;
        private long? _iupdate;
        private long _iAccountid;
        private string _vStatus;
        private string _vAddress1;
        private string _vAddress2;
        private string _vCity;
        private string _vState;
        private string _vZip;
        private string _vPhoneHome;
        private string _vPhoneOffice;
        private string _vPhoneCell;
        private string _vWorkStatus;

        private string _vComments;
        private string _vChartno;
        private string _vHowdidfindus;
        private string _vRelation;
        public string vRelation
        {
            set { _vRelation = value; OnPropertyChanged("vRelation"); }
            get { return _vRelation; }
        }

        private long _iPatAge;
        public long iPatAge
        {
            get { return _iPatAge; }
            set { _iPatAge = value; OnPropertyChanged("iPatAge"); }
        }


        public long IAccountid
        {
            get { return _iAccountid; }
            set { _iAccountid = value;  OnPropertyChanged("IAccountid");}
        }
      
        
       

       



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long iPatid
        {
            set { _iPatid = value;  OnPropertyChanged("iPatid");}
            get { return _iPatid; }
        }
        public string vFullName
        {
            set { _vFullName = value; OnPropertyChanged("vFullName"); }
            get { return _vFullName; }
        }

        public System.Nullable<System.DateTime> DOB
        {
            set { dDOB = value;  OnPropertyChanged("DOB");}
            get { return dDOB; }
        }

        public string vEmail
        {
            set { _vEmail = value;  OnPropertyChanged("vEmail");}
            get { return _vEmail; }
        }

        public string vFatherName
        {
            set { _vFatherName = value;  OnPropertyChanged("vFatherName");}
            get { return _vFatherName; }
        }

        public string vGender
        {
            set { _vGender = value;  OnPropertyChanged("vGender");}
            get { return _vGender; }
        }

        public Boolean bActive
        {
            set { _bActive = value;  OnPropertyChanged("bActive");}
            get { return _bActive; }
        }

       

        [NotMapped]
        public long? iUpdate
        {
            set { _iupdate = value;  OnPropertyChanged("iUpdate");}
            get { return _iupdate; }
        }



        public string vStatus
        {
            set { _vStatus = value;  OnPropertyChanged("vStatus");}
            get { return _vStatus; }
        }

      
        public string vAddress1
        {
            set { _vAddress1 = value;  OnPropertyChanged("vAddress1");}
            get { return _vAddress1; }
        }

        public string vAddress2
        {
            set { _vAddress2 = value;  OnPropertyChanged("vAddress2");}
            get { return _vAddress2; }
        }

        public string vZip
        {
            set { _vZip = value;  OnPropertyChanged("vZip");}
            get { return _vZip; }
        }

        public string vState
        {
            set { _vState = value;  OnPropertyChanged("vState");}
            get { return _vState; }
        }

        public string vCity
        {
            set { _vCity = value;  OnPropertyChanged("vCity");}
            get { return _vCity; }
        }

        public string vPhoneHome
        {
            set { _vPhoneHome = value;  OnPropertyChanged("vPhoneHome");}
            get { return _vPhoneHome; }
        }

        public string vPhoneOffice
        {
            set { _vPhoneOffice = value;  OnPropertyChanged("vPhoneOffice");}
            get { return _vPhoneOffice; }
        }

        public string vPhoneCell
        {
            set { _vPhoneCell = value;  OnPropertyChanged("vPhoneCell");}
            get { return _vPhoneCell; }
        }

        public string vWorkStatus
        {
            set { _vWorkStatus = value;  OnPropertyChanged("vWorkStatus");}
            get { return _vWorkStatus; }
        }

       

        public string vComments
        {
            set { _vComments = value;  OnPropertyChanged("vComments");}
            get { return _vComments; }
        }

        public string vChartno
        {
            set { _vChartno = value;  OnPropertyChanged("vChartno");}
            get { return _vChartno; }
        }

        public string vHowdidfindus
        {
            set { _vHowdidfindus = value;  OnPropertyChanged("vHowdidfindus");}
            get { return _vHowdidfindus; }
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

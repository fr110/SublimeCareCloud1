using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHolders
{
    [Table("scc_Appointments")]
    public class dhAppointment : INotifyPropertyChanged
    {
        private long _iAppid;
        private long _iPatid;
        private long _iDocid;
        private string vDocName;
        private string _vPatName;

        //private DateTime? _dDOB;
        private long _iPayment_Total;

        private long? _iPayment_Due;
        private string _vCheckup_Time;

        //private DateTime? _dAppolongment_Date;
        //private String _cEvening_Morning;
        private String _vVisitType;

        private long _iToken_Number;
        private string _ddSession;

        public string ddSession
        {
            get { return _ddSession; }
            set { _ddSession = value; OnPropertyChanged("ddSession"); }
        }

        //private long _accNumber;
        private DateTime? _sysDate;

        //private Nullable<long> _iAssitantDocID;
        private long? _iPayment_Recieved;

        //private DateTime? _dStartDate;
        //private DateTime? _dEndDate;
        //private string _vMultiAssistant;
        //private long _quaryCase;
        private DateTime? _AppointmentDate;

        public DateTime? AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; OnPropertyChanged("AppointmentDate"); }
        }

        public dhAppointment()
        {
            this.AppointmentDate = DateTime.Now;
            this.SysDate = DateTime.Now;
        }

        private DateTime? _AppointmentTime;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IAppid
        {
            get { return _iAppid; }
            set { _iAppid = value; OnPropertyChanged("IAppid"); }
        }

        public long IPatid
        {
            get { return _iPatid; }
            set { _iPatid = value; OnPropertyChanged("IPatid"); }
        }

        public long IDocid
        {
            get { return _iDocid; }
            set { _iDocid = value; OnPropertyChanged("IDocid"); }
        }

        [NotMapped]
        public string VDocName
        {
            get { return vDocName; }
            set { vDocName = value; OnPropertyChanged("VDocName"); }
        }

        [NotMapped]
        public string VPatName
        {
            get { return _vPatName; }
            set { _vPatName = value; OnPropertyChanged("VPatName"); }
        }

        //public DateTime? DDOB
        //{
        //    get { return _dDOB; }
        //    set { _dDOB =  value; OnPropertyChanged("VCompanyMobile"); }
        //}
        private long? _IPatientBalance;

        public long? IPatientBalance
        {
            get { return _IPatientBalance; }
            set { _IPatientBalance = value; OnPropertyChanged("IPatientBalance"); }
        }

        public long? IPayment_Recieved
        {
            get { return _iPayment_Recieved; }
            set
            {
                _iPayment_Recieved = value;
                IPatientBalance = IPayment_Due - IPayment_Recieved;

                OnPropertyChanged("IPayment_Recieved");
            }
        }

        public long IPayment_Total
        {
            get { return _iPayment_Total; }
            set { _iPayment_Total = value; OnPropertyChanged("IPayment_Total"); }
        }

        public long? IPayment_Due
        {
            get { return _iPayment_Due; }
            set
            {
                _iPayment_Due = value;
                IPayment_Recieved = IPayment_Due;
                OnPropertyChanged("IPayment_Due");
            }
        }

        public string VCheckup_Time
        {
            get { return _vCheckup_Time; }
            set { _vCheckup_Time = value; OnPropertyChanged("VCheckup_Time"); }
        }

        //public DateTime? DAppolongment_Date
        //{
        //    get { return _dAppolongment_Date; }
        //    set { _dAppolongment_Date =  value; OnPropertyChanged("VCompanyMobile"); }
        //}

        //public String CEvening_Morning
        //{
        //    get { return _cEvening_Morning; }
        //    set { _cEvening_Morning =  value; OnPropertyChanged("VCompanyMobile"); }
        //}

        public String VVisitType
        {
            get { return _vVisitType; }
            set { _vVisitType = value; OnPropertyChanged("VVisitType"); }
        }

        public long IToken_Number
        {
            get { return _iToken_Number; }
            set { _iToken_Number = value; OnPropertyChanged("IToken_Number"); }
        }

        private string _FormatedTokenNumber;

        public string FormatedTokenNumber
        {
            get { return _FormatedTokenNumber; }
            set { _FormatedTokenNumber = value; OnPropertyChanged("FormatedTokenNumber"); }
        }

        //public long IAccNumber
        //{
        //    get { return _accNumber; }
        //    set { _accNumber =  value; OnPropertyChanged("VCompanyMobile"); }
        //}

        public DateTime? SysDate
        {
            get { return _sysDate; }
            set { _sysDate = value; OnPropertyChanged("SysDate"); }
        }

        //public Nullable<long> IAssitantDocID
        //{
        //    get { return _iAssitantDocID; }
        //    set { _iAssitantDocID =  value; OnPropertyChanged("VCompanyMobile"); }
        //}

        //public DateTime? dStartDate

        //{
        //    get { return _dStartDate; }
        //    set { _dStartDate =  value; OnPropertyChanged("VCompanyMobile"); }
        //}

        //public DateTime? dEndDate
        //{
        //    get { return _dEndDate; }
        //    set { _dEndDate =  value; OnPropertyChanged("VCompanyMobile"); }
        //}
        //public long QuaryCase
        //{
        //    get { return _quaryCase; }
        //    set { _quaryCase =  value; OnPropertyChanged("VCompanyMobile"); }
        //}
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHolders
{
    // using existing name
    [Table("posEmployee")]
    public class dhEmployee : INotifyPropertyChanged
    {
        private int _iEmpid;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IEmpid
        {
            get { return _iEmpid; }
            set { _iEmpid = value; OnPropertyChanged("IEmpid"); }
        }

        private string _vTitle;

        public string VTitle
        {
            get { return _vTitle; }
            set { _vTitle = value; OnPropertyChanged("VTitle"); }
        }

        private string _vEmpfName;

        public string VEmpfName
        {
            get { return _vEmpfName; }
            set { _vEmpfName = value; OnPropertyChanged("VEmpfName"); }
        }

        private string _vEmpFatherName;

        public string VEmpFatherName
        {
            get { return _vEmpFatherName; }
            set { _vEmpFatherName = value; OnPropertyChanged("VEmpFatherName"); }
        }

        private string _vEmplName;

        public string VEmplName
        {
            get { return _vEmplName; }
            set { _vEmplName = value; OnPropertyChanged("VEmplName"); }
        }

        private string _vMartialStatus;

        public string VMartialStatus
        {
            get { return _vMartialStatus; }
            set { _vMartialStatus = value; OnPropertyChanged("VMartialStatus"); }
        }

        private string _vIdNumber;

        public string VIdNumber
        {
            get { return _vIdNumber; }
            set { _vIdNumber = value; OnPropertyChanged("VIdNumber"); }
        }

        private string _vPassportNo;

        public string VPassportNo
        {
            get { return _vPassportNo; }
            set { _vPassportNo = value; OnPropertyChanged("VPassportNo"); }
        }

        private string _vAddress;

        public string VAddress
        {
            get { return _vAddress; }
            set { _vAddress = value; OnPropertyChanged("VAddress"); }
        }

        private string _vCity;

        public string VCity
        {
            get { return _vCity; }
            set { _vCity = value; OnPropertyChanged("VCity"); }
        }

        private string _vEmployeeType;

        public string VEmployeeType
        {
            get { return _vEmployeeType; }
            set { _vEmployeeType = value; OnPropertyChanged("VEmployeeType"); }
        }

        //vEmployeeType

        //iMiscellaneous

        private int _iMiscellaneous;

        public int IMiscellaneous
        {
            get { return _iMiscellaneous; }
            set { _iMiscellaneous = value; }
        }

        //iHourlyRate
        private int _iHourlyRate;

        public int IHourlyRate
        {
            get { return _iHourlyRate; }
            set { _iHourlyRate = value; }
        }

        //iDeduction
        private int _iDeduction;

        public int IDeduction
        {
            get { return _iDeduction; }
            set { _iDeduction = value; }
        }

        //iTranid
        private int _iTranid;

        public int ITranid
        {
            get { return _iTranid; }
            set { _iTranid = value; }
        }

        private string _vNationality;

        public string VNationality
        {
            get { return _vNationality; }
            set { _vNationality = value; OnPropertyChanged("VNationality"); }
        }

        private string _iMobile;

        public string IMobile
        {
            get { return _iMobile; }
            set { _iMobile = value; OnPropertyChanged("IMobile"); }
        }

        private string _vDesignation;

        public string VDesignation
        {
            get { return _vDesignation; }
            set { _vDesignation = value; OnPropertyChanged("VDesignation"); }
        }

        private System.Nullable<System.DateTime> _dDateOfJoining;

        public System.Nullable<System.DateTime> DDateOfJoining
        {
            get { return _dDateOfJoining; }
            set { _dDateOfJoining = value; OnPropertyChanged("DDateOfJoining"); }
        }

        private string _vDescription;

        public string VDescription
        {
            get { return _vDescription; }
            set { _vDescription = value; OnPropertyChanged("VDescription"); }
        }

        private System.Nullable<bool> _Active;

        public System.Nullable<bool> Active
        {
            get { return _Active; }
            set { _Active = value; OnPropertyChanged("Active"); }
        }

        private System.Nullable<double> _iBasicSalary;

        public System.Nullable<double> IBasicSalary
        {
            get { return _iBasicSalary; }
            set { _iBasicSalary = value; OnPropertyChanged("IBasicSalary"); }
        }

        private System.Nullable<int> _iHousing;

        public System.Nullable<int> IHousing
        {
            get { return _iHousing; }
            set { _iHousing = value; OnPropertyChanged("IHousing"); }
        }

        private System.Nullable<int> _iTraveling;

        public System.Nullable<int> ITraveling
        {
            get { return _iTraveling; }
            set { _iTraveling = value; OnPropertyChanged("ITraveling"); }
        }

        private System.Nullable<int> _iTotalSalary;

        public System.Nullable<int> ITotalSalary
        {
            get { return _iTotalSalary; }
            set { _iTotalSalary = value; OnPropertyChanged("ITotalSalary"); }
        }

        private string _vLastPaidSalaryMonth;

        public string VLastPaidSalaryMonth
        {
            get { return _vLastPaidSalaryMonth; }
            set { _vLastPaidSalaryMonth = value; OnPropertyChanged("VLastPaidSalaryMonth"); }
        }

        private System.Nullable<System.DateTime> _dLastPaidSalaryDay;

        public System.Nullable<System.DateTime> DLastPaidSalaryDay
        {
            get { return _dLastPaidSalaryDay; }
            set { _dLastPaidSalaryDay = value; OnPropertyChanged("DLastPaidSalaryDay"); }
        }

        private System.Nullable<int> _iSalaryDue;

        public System.Nullable<int> ISalaryDue
        {
            get { return _iSalaryDue; }
            set { _iSalaryDue = value; OnPropertyChanged("ISalaryDue"); }
        }

        private System.Nullable<int> _iBalance;

        public System.Nullable<int> IBalance
        {
            get { return _iBalance; }
            set { _iBalance = value; OnPropertyChanged("IBalance"); }
        }

        private System.Nullable<int> _iEmpTypeId;

        public System.Nullable<int> IEmpTypeId
        {
            get { return _iEmpTypeId; }
            set { _iEmpTypeId = value; OnPropertyChanged("IEmpTypeId"); }
        }

        private int _iUpdate;

        [NotMapped]
        public int IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        private System.Nullable<int> iAccountid;
        private string _vAccountNo;
        //    [NotMapped]

        public string VAccountNo
        {
            get { return _vAccountNo; }
            set { _vAccountNo = value; OnPropertyChanged("VAccountNo"); }
        }

        //[NotMapped]
        public System.Nullable<int> IAccountid
        {
            get { return iAccountid; }
            set { iAccountid = value; OnPropertyChanged("IAccountid"); }
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

        private string _vEmployeeInfo;

        //    [NotMapped]
        public string VEmployeeInfo
        {
            get { return _vEmployeeInfo; }
            set { _vEmployeeInfo = value; OnPropertyChanged("VEmployeeInfo"); }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHolders
{
    [Table("scc_Doctors")]
    public class dhDoctors : INotifyPropertyChanged
    {
        public dhDoctors()
        {
            this.SuffixList = new Dictionary<string, string>();
            this.SuffixList.Add("Mr", "Mr");
            this.SuffixList.Add("Mrs", "Mrs");
        }

        private long _iDocid;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDocid
        {
            get { return _iDocid; }
            set { _iDocid = value; OnPropertyChanged("IDocid"); }
        }

        private Nullable<int> _iUpdate;

        [NotMapped]
        public Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        private string _vTitle;

        public string VTitle
        {
            get { return _vTitle; }
            set { _vTitle = value; OnPropertyChanged("VTitle"); }
        }

        [NotMapped]
        public Dictionary<string, string> SuffixList;

        private string _vSuffix;

        public string VSuffix
        {
            get { return _vSuffix; }
            set { _vSuffix = value; OnPropertyChanged("VSuffix"); }
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

        private string _fullName;

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.VfName + " " + this.VlName;
            }
            //set
            //{
            //    this._fullName = this.VfName + " " + this.VlName;
            //}
        }

        private ObservableCollection<dhSpecialization> _Specialization;

        [NotMapped]
        public ObservableCollection<dhSpecialization> Specialization
        {
            get;
            set;
            //OnPropertyChanged("Specialization");
        }

        private int? _iSpecializationId;

        public int? ISpecializationId
        {
            get { return _iSpecializationId; }
            set { _iSpecializationId = value; OnPropertyChanged("ISpecializationId"); }
        }

        private string _vQualification;

        public string VQualification
        {
            get { return _vQualification; }
            set { _vQualification = value; OnPropertyChanged("VQualification"); }
        }

        private Nullable<DateTime> _dJoiningDate;

        public Nullable<DateTime> DJoiningDate
        {
            get { return _dJoiningDate; }
            set { _dJoiningDate = value; OnPropertyChanged("DJoiningDate"); }
        }

        private Nullable<DateTime> _dDOB;

        public Nullable<DateTime> DDOB
        {
            get { return _dDOB; }
            set { _dDOB = value; OnPropertyChanged("DDOB"); }
        }

        private string _vMartialStatus;

        public string VMartialStatus
        {
            get { return _vMartialStatus; }
            set { _vMartialStatus = value; OnPropertyChanged("VMartialStatus"); }
        }

        private string _vGender;

        public string VGender
        {
            get { return _vGender; }
            set { _vGender = value; OnPropertyChanged("VGender"); }
        }

        private string _vFatherName;

        public string VFatherName
        {
            get { return _vFatherName; }
            set { _vFatherName = value; OnPropertyChanged("VFatherName"); }
        }

        private string _vSSN;

        public string VSSN
        {
            get { return _vSSN; }
            set { _vSSN = value; OnPropertyChanged("VSSN"); }
        }

        private string _vNPI;

        public string VNPI
        {
            get { return _vNPI; }
            set { _vNPI = value; OnPropertyChanged("VNPI"); }
        }

        private string _vDEA;

        public string VDEA
        {
            get { return _vDEA; }
            set { _vDEA = value; OnPropertyChanged("VDEA"); }
        }

        private string _vLicNumber;

        public string VLicNumber
        {
            get { return _vLicNumber; }
            set { _vLicNumber = value; OnPropertyChanged("VLicNumber"); }
        }

        private string _vLicState;

        public string VLicState
        {
            get { return _vLicState; }
            set { _vLicState = value; OnPropertyChanged("VLicState"); }
        }

        //private string _vTaxType;

        //public string VTaxType
        //{
        //    get { return _vTaxType; }
        //    set { _vTaxType = value; OnPropertyChanged("VTaxType"); }
        //}
        //private string _vTaxID;

        //public string VTaxID
        //{
        //    get { return _vTaxID; }
        //    set { _vTaxID = value; OnPropertyChanged("VTaxID"); }
        //}
        private string _vAddress1;

        public string VAddress1
        {
            get { return _vAddress1; }
            set { _vAddress1 = value; OnPropertyChanged("VAddress1"); }
        }

        private string _vAddress2;

        public string VAddress2
        {
            get { return _vAddress2; }
            set { _vAddress2 = value; OnPropertyChanged("VAddress2"); }
        }

        //private string _vCity;

        //public string VCity
        //{
        //    get { return _vCity; }
        //    set { _vCity = value; OnPropertyChanged("VCity"); }
        //}
        //private string _vState;

        //public string VState
        //{
        //    get { return _vState; }
        //    set { _vState = value; OnPropertyChanged("VState"); }
        //}
        //private string _vZip;

        //public string VZip
        //{
        //    get { return _vZip; }
        //    set { _vZip = value; OnPropertyChanged("VZip"); }
        //}
        //private string _vProvince;

        //public string VProvince
        //{
        //    get { return _vProvince; }
        //    set { _vProvince = value; OnPropertyChanged("VProvince"); }
        //}
        private string _vHomePhone;

        public string VHomePhone
        {
            get { return _vHomePhone; }
            set { _vHomePhone = value; OnPropertyChanged("VHomePhone"); }
        }

        private string _vWorkPhone;

        public string VWorkPhone
        {
            get { return _vWorkPhone; }
            set { _vWorkPhone = value; OnPropertyChanged("VWorkPhone"); }
        }

        private string _vMobile;

        public string VMobile
        {
            get { return _vMobile; }
            set { _vMobile = value; OnPropertyChanged("VMobile"); }
        }

        private string _vHospital;

        public string VHospital
        {
            get { return _vHospital; }
            set { _vHospital = value; OnPropertyChanged("VHospital"); }
        }

        private string _vEmail;

        public string VEmail
        {
            get { return _vEmail; }
            set { _vEmail = value; OnPropertyChanged("VEmail"); }
        }

        private Nullable<Boolean> _bActive = false;

        public Nullable<Boolean> BActive
        {
            get { return _bActive; }
            set { _bActive = value; OnPropertyChanged("BActive"); }
        }

        private Nullable<Boolean> _bRendering = false;

        public Nullable<Boolean> BRendering
        {
            get { return _bRendering; }
            set { _bRendering = value; OnPropertyChanged("BRendering"); }
        }

        private Nullable<Boolean> _bBilling = false;

        public Nullable<Boolean> BBilling
        {
            get { return _bBilling; }
            set { _bBilling = value; OnPropertyChanged("BBilling"); }
        }

        private Nullable<Boolean> _bPay_to_Provider = false;

        public Nullable<Boolean> BPay_to_Provider
        {
            get { return _bPay_to_Provider; }
            set { _bPay_to_Provider = value; OnPropertyChanged("BPay_to_Provider"); }
        }

        private Nullable<Boolean> _bSupervising = false;

        public Nullable<Boolean> BSupervising
        {
            get { return _bSupervising; }
            set { _bSupervising = value; OnPropertyChanged("BSupervising"); }
        }

        private Nullable<Boolean> _bPysician_Assitant = false;

        public Nullable<Boolean> BPysician_Assitant
        {
            get { return _bPysician_Assitant; }
            set { _bPysician_Assitant = value; OnPropertyChanged("BPysician_Assitant"); }
        }

        private Nullable<Boolean> _bOperating = false;

        public Nullable<Boolean> BOperating
        {
            get { return _bOperating; }
            set { _bOperating = value; OnPropertyChanged("BOperating"); }
        }

        private Nullable<Boolean> _bAssitant_Surgeon = false;

        public Nullable<Boolean> BAssitant_Surgeon
        {
            get { return _bAssitant_Surgeon; }
            set { _bAssitant_Surgeon = value; OnPropertyChanged("BAssitant_Surgeon"); }
        }

        private Nullable<Boolean> _bPurchaed_Services = false;

        public Nullable<Boolean> BPurchaed_Services
        {
            get { return _bPurchaed_Services; }
            set { _bPurchaed_Services = value; OnPropertyChanged("BPurchaed_Services"); }
        }

        private Nullable<Boolean> _bPAtteding = false;

        public Nullable<Boolean> BPAtteding
        {
            get { return _bPAtteding; }
            set { _bPAtteding = value; OnPropertyChanged("BPAtteding"); }
        }

        private Nullable<int> _iPracID;

        public Nullable<int> IPracID
        {
            get { return _iPracID; }
            set { _iPracID = value; OnPropertyChanged("IPracID"); }
        }

        private string _vMediCare_Doctor_Type;

        public string VMediCare_Doctor_Type
        {
            get { return _vMediCare_Doctor_Type; }
            set { _vMediCare_Doctor_Type = value; OnPropertyChanged("VMediCare_Doctor_Type"); }
        }

        private string _vEvening_Time_Start;

        public string VEvening_Time_Start
        {
            get { return _vEvening_Time_Start; }
            set { _vEvening_Time_Start = value; OnPropertyChanged("VEvening_Time_Start"); }
        }

        private string _vEvening_Time_End;

        public string VEvening_Time_End
        {
            get { return _vEvening_Time_End; }
            set { _vEvening_Time_End = value; OnPropertyChanged("VEvening_Time_End"); }
        }

        private string _vMorning_Time_Start;

        public string VMorning_Time_Start
        {
            get { return _vMorning_Time_Start; }
            set { _vMorning_Time_Start = value; OnPropertyChanged("VMorning_Time_Start"); }
        }

        private string _vMorning_Time_End;

        public string VMorning_Time_End
        {
            get { return _vMorning_Time_End; }
            set { _vMorning_Time_End = value; OnPropertyChanged("VMorning_Time_End"); }
        }

        private Nullable<int> _iHospital_Charges;

        public Nullable<int> IHospital_Charges
        {
            get { return _iHospital_Charges; }
            set { _iHospital_Charges = value; OnPropertyChanged("IHospital_Charges"); }
        }

        private Nullable<int> _iPatient_Fee;

        public Nullable<int> IPatient_Fee
        {
            get { return _iPatient_Fee; }
            set { _iPatient_Fee = value; OnPropertyChanged("IPatient_Fee"); }
        }

        private Nullable<int> _iReturning_Patient_Fee;

        public Nullable<int> IReturning_Patient_Fee
        {
            get { return _iReturning_Patient_Fee; }
            set { _iReturning_Patient_Fee = value; OnPropertyChanged("IReturning_Patient_Fee"); }
        }

        private Nullable<int> _iPatient_Token_Limit;

        public Nullable<int> IPatient_Token_Limit
        {
            get { return _iPatient_Token_Limit; }
            set { _iPatient_Token_Limit = value; OnPropertyChanged("IPatient_Token_Limit"); }
        }

        private long _iBasicSalary;

        public long IBasicSalary
        {
            get { return _iBasicSalary; }

            set
            {
                _iBasicSalary = value; OnPropertyChanged("IBasicSalary");
            }
        }

        private long? _iAccountid;

        public long? IAccountid
        {
            get { return _iAccountid; }
            set { _iAccountid = value; OnPropertyChanged("IAccountid"); }
        }

        private string _vUsers;

        public string VUsers
        {
            get { return _vUsers; }
            set { _vUsers = value; OnPropertyChanged("VUsers"); }
        }

        private string _vSureScriptid;

        public string VSureScriptid
        {
            get { return _vSureScriptid; }
            set { _vSureScriptid = value; OnPropertyChanged("VSureScriptid"); }
        }

        private string _vAssistantDocIDs;

        public string VAssistantDocIDs
        {
            get { return _vAssistantDocIDs; }
            set { _vAssistantDocIDs = value; OnPropertyChanged("VAssistantDocIDs"); }
        }

        // creating relations with other entities

        private string _TokenStart;

        public string TokenStart
        {
            get { return _TokenStart; }
            set { _TokenStart = value; OnPropertyChanged("TokenStart"); }
        }

        [NotMapped]
        public ObservableCollection<DocInvestigations> DocInvestigations { get; set; }

        //[NotMapped]
        // public dhAccount DocAccount { get; set; }

        [NotMapped]
        public ObservableCollection<Investigations> Investigations { get; set; }

        [NotMapped]
        public ObservableCollection<dhProcedure> Procedures { get; set; }

        [NotMapped]
        public ObservableCollection<dhDocProcedures> DocProcedures { get; set; }

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
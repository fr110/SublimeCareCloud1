using System;

namespace DataHolders
{
    public class dhDoctorView
    {
        private string _VSuffix;
        private string _VGender;
        private string _VFullName;
        private string _VfName;
        private string _VlName;
        private string _VFatherName;
        private DateTime? _DDOB;
        private DateTime? _dJoiningDate;
        private int? _ISpecializationId;
        private string _vSpecializationName;
        private string _VMobile;
        private string _VEmail;
        private Boolean? _BActive;
        private int? _IPatient_Fee;
        private int? _IReturning_Patient_Fee;
        private int? _IPatient_Token_Limit;
        private int? _IHospital_Charges;

        private long? _IAccountid;
        private string _VAccountNo;
        private string _AccountName;

        private int? _IFinaceType;
        private string _vFinaceType;

        private long _IDocid;
        private string _VTitle;

        public string VSuffix { get { return _VSuffix; } set { _VSuffix = value; } }
        public string VGender { get { return _VGender; } set { _VGender = value; } }
        public string VFullName { get { return _VFullName; } set { _VFullName = value; } }
        public string VfName { get { return _VfName; } set { _VfName = value; } }
        public string VlName { get { return _VlName; } set { _VlName = value; } }
        public string VFatherName { get { return _VFatherName; } set { _VFatherName = value; } }
        public DateTime? DDOB { get { return _DDOB; } set { _DDOB = value; } }
        public DateTime? DJoiningDate { get { return _dJoiningDate; } set { _dJoiningDate = value; } }

        public int? ISpecializationId { get { return _ISpecializationId; } set { _ISpecializationId = value; } }
        public string VSpecializationName { get { return _vSpecializationName; } set { _vSpecializationName = value; } }
        public string VMobile { get { return _VMobile; } set { _VMobile = value; } }
        public string VEmail { get { return _VEmail; } set { _VEmail = value; } }
        public bool? BActive { get { return _BActive; } set { _BActive = value; } }
        public int? IPatient_Fee { get { return _IPatient_Fee; } set { _IPatient_Fee = value; } }
        public int? IReturning_Patient_Fee { get { return _IReturning_Patient_Fee; } set { _IReturning_Patient_Fee = value; } }
        public int? IPatient_Token_Limit { get { return _IPatient_Token_Limit; } set { _IPatient_Token_Limit = value; } }
        public int? IHospital_Charges { get { return _IHospital_Charges; } set { _IHospital_Charges = value; } }
        public long? IAccountid { get { return _IAccountid; } set { _IAccountid = value; } }
        public string VAccountNo { get { return _VAccountNo; } set { _VAccountNo = value; } }
        public string AccountName { get { return _AccountName; } set { _AccountName = value; } }
        public int? IFinaceType { get { return _IFinaceType; } set { _IFinaceType = value; } }
        public string VFinaceType { get { return _vFinaceType; } set { _vFinaceType = value; } }
        public long IDocid { get { return _IDocid; } set { _IDocid = value; } }
        public string VTitle { get { return _VTitle; } set { _VTitle = value; } }
    }
}
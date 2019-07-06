using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    [Table("scc_Appointments")]
    public class dhAppointment
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
            set { _ddSession = value; }
        }
        //private long _accNumber;
        private DateTime? _sysDate;
        //private Nullable<long> _iAssitantDocID;
        private long _iPayment_Recieved;
        //private DateTime? _dStartDate;
        //private DateTime? _dEndDate;
        //private string _vMultiAssistant;
        //private long _quaryCase;
        private DateTime? _AppointmentDate;
        public DateTime? AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; }
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
            set { _iAppid = value; }
        }

        public long IPatid
        {
            get { return _iPatid; }
            set { _iPatid = value; }
        }

        public long IDocid
        {
            get { return _iDocid; }
            set { _iDocid = value; }
        }


        [NotMapped]
        public string VDocName
        {
            get { return vDocName; }
            set { vDocName = value; }
        }

        [NotMapped]
        public string VPatName
        {
            get { return _vPatName; }
            set { _vPatName = value; }
        }

        //public DateTime? DDOB
        //{
        //    get { return _dDOB; }
        //    set { _dDOB = value; }
        //}
        public long IPayment_Recieved
        {
            get { return _iPayment_Recieved; }
            set { _iPayment_Recieved = value; }
        }

        public long IPayment_Total
        {
            get { return _iPayment_Total; }
            set { _iPayment_Total = value; }
        }

        public long? IPayment_Due
        {
            get { return _iPayment_Due; }
            set { _iPayment_Due = value; }
        }


        public string VCheckup_Time
        {
            get { return _vCheckup_Time; }
            set { _vCheckup_Time = value; }
        }


        //public DateTime? DAppolongment_Date
        //{
        //    get { return _dAppolongment_Date; }
        //    set { _dAppolongment_Date = value; }
        //}

        //public String CEvening_Morning
        //{
        //    get { return _cEvening_Morning; }
        //    set { _cEvening_Morning = value; }
        //}


        public String VVisitType
        {
            get { return _vVisitType; }
            set { _vVisitType = value; }
        }

        public long IToken_Number
        {
            get { return _iToken_Number; }
            set { _iToken_Number = value; }
        }

        private string _FormatedTokenNumber;
        public string FormatedTokenNumber
        {
            get { return _FormatedTokenNumber; }
            set { _FormatedTokenNumber = value; }
        }

        //public long IAccNumber
        //{
        //    get { return _accNumber; }
        //    set { _accNumber = value; }
        //}


        public DateTime? SysDate
        {
            get { return _sysDate; }
            set { _sysDate = value; }
        }


        //public Nullable<long> IAssitantDocID
        //{
        //    get { return _iAssitantDocID; }
        //    set { _iAssitantDocID = value; }
        //}

        //public DateTime? dStartDate

        //{
        //    get { return _dStartDate; }
        //    set { _dStartDate = value; }
        //}

        //public DateTime? dEndDate
        //{
        //    get { return _dEndDate; }
        //    set { _dEndDate = value; }
        //}
        //public long QuaryCase
        //{
        //    get { return _quaryCase; }
        //    set { _quaryCase = value; }
        //}
    }
}

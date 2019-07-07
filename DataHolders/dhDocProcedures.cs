using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHolders
{
    [Table("scc_DocProcedures")]
    public class dhDocProcedures : INotifyPropertyChanged
    {
        private long _iDocProceduresId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDocProceduresId
        {
            get { return _iDocProceduresId; }
            set { _iDocProceduresId = value; OnPropertyChanged("IDocProceduresId"); }
        }

        private long _IProcedureId;

        public long IProcedureId
        {
            get { return _IProcedureId; }
            set { _IProcedureId = value; OnPropertyChanged("IProcedureId"); }
        }

        private long _iDocid;

        public long IDocid
        {
            get { return _iDocid; }
            set { _iDocid = value; OnPropertyChanged("IDocid"); }
        }

        private long _iDocCommission;

        public long IDocCommission
        {
            get { return _iDocCommission; }
            set { _iDocCommission = value; OnPropertyChanged("IDocCommission"); }
        }

        //relations
        public ObservableCollection<dhDoctors> Doctor { get; set; }

        private string _vProcedureName;

        [NotMapped]
        public string VProcedureName
        {
            get { return _vProcedureName; }
            set { _vProcedureName = value; }
        }

        private string _vProcedureDesc;

        [NotMapped]
        public string VProcedureDesc
        {
            get { return _vProcedureDesc; }
            set { _vProcedureDesc = value; }
        }

        private int _iProcedureCharges;

        [NotMapped]
        public int IProcedureCharges
        {
            get { return _iProcedureCharges; }
            set { _iProcedureCharges = value; }
        }

        private Boolean _bIsActive;

        public Boolean BIsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
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
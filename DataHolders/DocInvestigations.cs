using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    [Table("scc_DocInvestigations")]
    public class DocInvestigations : INotifyPropertyChanged
    {
        private long _iDocInvestigationsId;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long  IDocInvestigationsId
        {
            get { return _iDocInvestigationsId; }
            set { _iDocInvestigationsId = value; OnPropertyChanged("IDocInvestigationsId"); }
        }

        private long _iInvid;
        public long IInvid
        {
            get { return _iInvid; }
            set { _iInvid = value; OnPropertyChanged("IInvid"); }
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

        private string _vInvName;
        [NotMapped]
        public string VInvName
        {
            get { return _vInvName; }
            set { _vInvName = value; }
        }

        private string _vInvDesc;
        [NotMapped]
        public string VInvDesc
        {
            get { return _vInvDesc; }
            set { _vInvDesc = value; }
        }

        private int _iInvCharges;
        [NotMapped]
        public int IInvCharges
        {
            get { return _iInvCharges; }
            set { _iInvCharges = value; }
        }

        private Boolean _bIsActive;
        public Boolean BIsActive {
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

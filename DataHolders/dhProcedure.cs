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
    [Table("scc_Procedures")]
   public class dhProcedure :  INotifyPropertyChanged
    {
        private int _IProcedureId;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IProcedureId
        {
            get { return _IProcedureId; }
            set { _IProcedureId = value; OnPropertyChanged("IProcedureId"); }
        }

        private string _VProcedureName;

        public string VProcedureName
        {
            get { return _VProcedureName; }
            set { _VProcedureName = value; }
        }

        private string _VProcedureDesc;

        public string VProcedureDesc
        {
            get { return _VProcedureDesc; }
            set { _VProcedureDesc = value; }
        }

        private int _iProCharges;

        public int IProCharges
        {
            get { return _iProCharges; }
            set { _iProCharges = value; }
        }

        private Boolean _bIsActive;
        public Boolean BIsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }
        private int _iUpdate;

        [NotMapped]
        public int IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; }
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

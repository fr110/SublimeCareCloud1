using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataHolders
{
    [Table("scc_Investigations")]
    public class Investigations
    {
        private long _iInvid;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IInvid
        {
            get { return _iInvid; }
            set { _iInvid = value; }
        }

        private string _vInvName;

        public string VInvName
        {
            get { return _vInvName; }
            set { _vInvName = value; }
        }

        private string _vInvDesc;

        public string VInvDesc
        {
            get { return _vInvDesc; }
            set { _vInvDesc = value; }
        }

        private int _iCharges;

        public int IInvCharges
        {
            get { return _iCharges; }
            set { _iCharges = value; }
        }

        public Boolean bIsActive { get; set; }
        private int _iUpdate;

        [NotMapped]
        public int IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; }
        }
    }
}
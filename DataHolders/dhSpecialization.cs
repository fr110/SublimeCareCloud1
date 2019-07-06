using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    [Table("scc_Specializations")]
    public class dhSpecialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int?      iSpecializationId { get; set; }
        public string  vSpecializationName  { get; set; }
        public Boolean bIsActive { get; set; }

    }
}

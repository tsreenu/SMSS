using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSModels
{
    public class States
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTimeOffset? CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}

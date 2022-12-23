using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSModels
{
    public class ClassDetails
    {
        public ClassDetails()
        {
            SectionDetails = new HashSet<SectionDetails>();
            SubjectDetails = new HashSet<SubjectDetails>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; } = string.Empty;
        //[Required]
        public string SchoolId { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;

        //[NotMapped]
        //public bool IsExpanded { get; set; } = false;

        public virtual ICollection<SectionDetails> SectionDetails { get; set; }
        public virtual ICollection<SubjectDetails> SubjectDetails { get; set; }

    }
}

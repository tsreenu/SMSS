using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSModels
{
    public class SectionDetails
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int MaxStudents { get; set; } = 60;
        public int SectionTeacherId { get; set; } = 0;
        public int? ClassId { get; set; }
        public bool IsActive { get; set; }

        public virtual ClassDetails? Class { get; set; }
    }
}

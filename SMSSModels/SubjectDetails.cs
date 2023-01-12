using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSModels
{
    public class SubjectDetails
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public int SubjectTeacher { get; set; }
        public int? ClassId { get; set; }
        public bool IsActive { get; set; }

        public virtual ClassDetails? Class { get; set; }
    }
}

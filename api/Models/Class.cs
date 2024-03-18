using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Class
    {
        public Class()
        {
            Contests = new HashSet<Contest>();
            StudentsClasses = new HashSet<StudentsClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? TeacherId { get; set; }

        public virtual User? Teacher { get; set; }
        public virtual ICollection<Contest> Contests { get; set; }
        public virtual ICollection<StudentsClass> StudentsClasses { get; set; }
    }
}

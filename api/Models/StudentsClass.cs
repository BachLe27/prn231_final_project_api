using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class StudentsClass
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}

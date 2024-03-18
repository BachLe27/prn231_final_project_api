using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Contests = new HashSet<Contest>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}

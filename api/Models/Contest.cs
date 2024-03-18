using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Contest
    {
        public Contest()
        {
            Submissions = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Question { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

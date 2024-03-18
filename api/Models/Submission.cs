using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Submission
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? StudentId { get; set; }
        public int? ContestId { get; set; }
        public decimal? Grade { get; set; }
        public DateTime? SubmissionTime { get; set; }

        public virtual Contest? Contest { get; set; }
        public virtual User? Student { get; set; }
    }
}

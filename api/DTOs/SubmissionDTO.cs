using api.Models;

namespace api.DTOs
{
    public class SubmissionDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? Grade { get; set; }
        public string? TeacherFeedback { get; set; }
        public DateTime? SubmissionTime { get; set; }

        public virtual ContestDTO? Contest { get; set; }
        public virtual StudentDTO? Student { get; set; }
    }
}

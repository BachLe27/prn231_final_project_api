namespace api.DTOs
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? TeacherId { get; set; }

        public string TeacherName { get; set; }
    }
}

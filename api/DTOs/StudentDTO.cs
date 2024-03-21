namespace api.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;        
        public string? Fullname { get; set; }
        public string Role { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

namespace api.DTOs
{
    public class ContestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Question { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}

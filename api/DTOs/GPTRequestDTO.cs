namespace api.DTOs
{
    public class GPTRequestDTO
    {
        public string? requirement { get; set; }
        public string? question { get; set; } 
        public string? student_answer { get; set; }

        public string ToString() => requirement + "\n" + question + "\n" + student_answer;
    }
}

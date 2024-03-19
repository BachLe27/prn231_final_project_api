using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            Classes = new HashSet<Class>();
            StudentsClasses = new HashSet<StudentsClass>();
            Submissions = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string Role { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<StudentsClass> StudentsClasses { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

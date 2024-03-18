using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            Classes = new HashSet<Class>();
            Submissions = new HashSet<Submission>();
            ClassesNavigation = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }

        public virtual ICollection<Class> ClassesNavigation { get; set; }
    }
}

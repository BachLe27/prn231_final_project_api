﻿namespace api.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}

using api.DTOs.Auth;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly project_prn231Context _dbcontext;
        public AuthController(IConfiguration config, project_prn231Context dbcontext)
        {
            _config = config;
            _dbcontext = dbcontext;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginDTO loginRequest)
        {

            var foundUser = _dbcontext.Users
                .Where(s => s.Username.Equals(loginRequest.username) && s.Password.Equals(loginRequest.password)).FirstOrDefault();

            if (foundUser != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginRequest.username),
                };

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);


                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                var response = new
                {
                    message = "Login successful",
                    user = foundUser,
                    token = token
                };

                return Ok(response);
            }
            else return this.BadRequest("Invalid credentials");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO registerRequest)
        {
            // Check if the username is already taken
            if (_dbcontext.Users.Any(u => u.Username == registerRequest.Username))
            {
                return Conflict("Tài khoản đã tồn tại");
            }

            // Create a new user
            var newUser = new User
            {
                Username = registerRequest.Username,
                Password = registerRequest.Password,
                Email = registerRequest.Email,
                Phone = registerRequest.Phone,
                Fullname = registerRequest.Fullname,
                Role = registerRequest.Role
                // You may need to populate other properties of your User entity based on your schema
            };

            _dbcontext.Users.Add(newUser);
            _dbcontext.SaveChanges();

            return Ok("User registered successfully");  
        }

    }
}

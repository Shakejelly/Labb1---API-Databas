using Labb1___API_Databas.Data;
using Labb1___API_Databas.Migrations;
using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly IConfiguration _configuration;
        public UserController(RestaurantContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        [Authorize]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            var existingUser = _context.Admins.SingleOrDefault(u => u.Email == registerUser.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already in use");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);
            var newAccount = new User
            {
                Email = registerUser.Email,
                PasswordHash = passwordHash
            };
            _context.Admins.Add(newAccount);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("Login")]
        public IActionResult Login(RegisterUserDto loginUser)
        {
            var user = _context.Admins.SingleOrDefault(u =>u.Email == loginUser.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password");
            }
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email, user.Email)
            }
            );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

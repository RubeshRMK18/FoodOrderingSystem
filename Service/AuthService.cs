using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodOrderingSystem.Service
{
    public class AuthService
    {
        private readonly AppDbcontext _context;

        private readonly IConfiguration _configuration;

        private readonly PasswordHasher<User> _passwordHasher;
        public AuthService(AppDbcontext context, IConfiguration configuration, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = passwordHasher;

        }
        public string Register(RegisterDTO registerDTO)
        {
            var checkuser = _context.Users.FirstOrDefault(u => u.Username == registerDTO.Username);
            if (checkuser != null)
            {
                return "User already exists";
            }

            var user = new User
            {
                Id = registerDTO.Id,
                Username = registerDTO.Username,
                HashPassword = ""
            };

            user.HashPassword = _passwordHasher.HashPassword(user, registerDTO.Password);
            _context.Users.Add(user);
            _context.SaveChanges();

            return "Registered Sucessfully";
        }

        public string Login(LoginDTO dto)
        {
            var Loginuser = _context.Users.FirstOrDefault(u => u.Username == dto.UserName);
            if (Loginuser == null)
            {
                return "Add User Details";
            }

            // Verify the password
            var result = _passwordHasher.VerifyHashedPassword(Loginuser, Loginuser.HashPassword, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return "Invalid password";
            }

            return GenerateToken(Loginuser);
        }

        public string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


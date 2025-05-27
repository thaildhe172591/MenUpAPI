using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkinShopAPI.Data;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SkinShopAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly SkincareShopForMenContext _context;
        private readonly EmailService _emailService;

        public AuthController(IConfiguration configuration, SkincareShopForMenContext context, 
            EmailService emailService)
        {
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName || u.Email == model.Email);
            if (existing != null)
                return BadRequest(new { Status = "Error", Message = "User or Email already exists" });


           // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var verification = new EmailVerification
            {
                Email = model.Email,
                Username = model.UserName,
                PasswordHash = passwordHash,
                FullName = model.FullName,
                OtpCode = otp,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMinutes(10),
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth
            };

            _context.EmailVerifications.Add(verification);
            await _context.SaveChangesAsync();

            await _emailService.SendEmailAsync(model.Email, "OTP Verification", $"Your OTP is: <b>{otp}</b>");

            return Ok(new { Status = "Success", Message = "OTP sent to email",
                Email = model.Email, 
                Username = model.UserName, 
                FullName = model.FullName,
              
            });
        }


        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            var verify = await _context.EmailVerifications.FirstOrDefaultAsync(e =>
            e.Email == dto.Email && e.OtpCode == dto.OtpCode);

            if (verify == null || verify.ExpiredAt < DateTime.UtcNow)
                return BadRequest(new { Status = "Error", Message = "OTP is invalid or expired" });

            // Tạo user từ thông tin xác thực
            var user = new User
            {
                Email = verify.Email,
                UserName = verify.Username!,
                PasswordHash = verify.PasswordHash,
                FullName = verify.FullName,
                Gender = verify.Gender,
                DateOfBirth = verify.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                RoleId = 3,
                IsVerified = true
            };

            _context.Users.Add(user);
            _context.EmailVerifications.Remove(verify);
            await _context.SaveChangesAsync();

            return Ok(new { 
                Status = "Success",    
                Message = "Account verified and created",
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == model.UserName);
            // Kiểm tra user có tồn tại không và mật khẩu có đúng không
            // Sử dụng BCrypt để so sánh mật khẩu đã hash
            // Nếu không có user hoặc mật khẩu không đúng, trả về Unauthorized
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return Unauthorized(new { Status = "Error", Message = "Invalid username or password." });
            }

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Status = "Success",
                Message = "Login successful",
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role?.RoleName ?? "Guest",
                Token = token
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
          {
           new Claim(JwtRegisteredClaimNames.Sub, user.Email),
         new Claim("UserId", user.UserId.ToString()),
          new Claim(ClaimTypes.Name, user.UserName ?? ""),
        new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User"),
         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresInMinutes"]!)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}

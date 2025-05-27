using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        private readonly SkincareShopForMenContext _context;

        public UsersController(IUserService userService , SkincareShopForMenContext context)
        {
            _userService = userService;
            _context = context;
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Staff")] // Only allow Admins and Staff to access this endpoint
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Staff")] // Only allow Admins and Staff to access this endpoint
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("createUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email đã được sử dụng.");
            }

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.FullName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId,
                CreatedAt = DateTime.UtcNow,
                IsVerified = dto.IsVerified,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) // ✅ Dùng BCrypt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            if (id != dto.UserId)
                return BadRequest("User ID mismatch.");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.FullName = dto.FullName;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.Gender = dto.Gender;
            user.DateOfBirth = dto.DateOfBirth;
            user.IsVerified = dto.IsVerified;
            user.RoleId = dto.RoleId;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }

}

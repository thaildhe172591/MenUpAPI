namespace SkinShopAPI.DTOs
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? IsVerified { get; set; }

        public int? RoleId { get; set; }
    }
}

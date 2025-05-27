namespace SkinShopAPI.DTOs
{
    public class RegisterModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public string UserName { get; set; } = null!;
    }
}

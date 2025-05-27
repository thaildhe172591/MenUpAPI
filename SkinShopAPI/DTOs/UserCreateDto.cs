namespace SkinShopAPI.DTOs
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string PasswordHash { get; set; } // hoặc Password nếu hash trong backend
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int RoleId { get; set; }

        public bool? IsVerified { get; set; }
    }

}

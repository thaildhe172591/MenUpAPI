namespace SkinShopAPI.DTOs
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //public string? RememberMe { get; set; } // Nullable to allow for no value
    }
}

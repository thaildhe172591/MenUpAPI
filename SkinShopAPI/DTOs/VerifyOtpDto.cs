namespace SkinShopAPI.DTOs
{
    public class VerifyOtpDto
    {
        public string Email { get; set; } = null!;
        public string OtpCode { get; set; } = null!;
    }
}

namespace SkinShopAPI.Models
{
    public class EmailSettings
    {
        public string FromName { get; set; } = null!;
        public string FromAddress { get; set; } = null!;
        public string SmtpServer { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

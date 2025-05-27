namespace SkinShopAPI.DTOs
{
    public class CreateProductReviewDto
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }


}

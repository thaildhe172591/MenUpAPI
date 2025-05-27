namespace SkinShopAPI.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }
        public string GenderTarget { get; set; }
        public string AffiliateLink { get; set; }
    }
}

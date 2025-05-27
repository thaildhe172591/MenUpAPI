namespace SkinShopAPI.DTOs
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime AddedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string ImageUrl { get; set; } // 👈 Thêm dòng này
    }


}

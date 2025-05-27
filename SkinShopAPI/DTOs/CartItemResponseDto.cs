namespace SkinShopAPI.DTOs
{
    public class CartItemResponseDto
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime? AddedAt { get; set; }

        public string? ImageUrl { get; set; } // Optional, can be null if not provided
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}

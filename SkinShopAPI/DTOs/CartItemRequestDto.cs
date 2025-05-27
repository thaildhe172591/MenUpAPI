using Org.BouncyCastle.Bcpg;

namespace SkinShopAPI.DTOs
{
    public class CartItemRequestDto
    {
        
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int CartItemId { get; set; }

        public int? UserId { get; set; }

    }
}

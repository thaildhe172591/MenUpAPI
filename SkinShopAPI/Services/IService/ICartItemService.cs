using SkinShopAPI.DTOs;
using SkinShopAPI.Models;

namespace SkinShopAPI.Services.IService
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemResponseDto>> GetUserCartAsync(int userId);
        Task<CartItemResponseDto> AddToCartAsync(int userId, CartItemRequestDto dto);
        Task<bool> RemoveFromCartAsync(int cartItemId);
        Task<bool> ClearCartAsync(int userId);
        Task<CartItemResponseDto?> UpdateCartItemAsync(int cartItemId, int newQuantity);
    }
}

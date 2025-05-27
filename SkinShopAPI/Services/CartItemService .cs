using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;
using System;

namespace SkinShopAPI.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repo;
        private readonly IProductRepository _productRepo;


        public CartItemService(ICartItemRepository repo, IProductRepository productRepo)
        {
            _repo = repo;
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<CartItemResponseDto>> GetUserCartAsync(int userId)
        {
            var items = await _repo.GetCartItemsByUserIdAsync(userId);
            return items.Select(c => new CartItemResponseDto
            {
                CartItemId = c.CartItemId,
                ProductId = c.ProductId!.Value,
                ProductName = c.Product!.Name,
                Quantity = c.Quantity!.Value,
                UnitPrice = c.Product.Price,
                AddedAt =  c.AddedAt,
               ImageUrl = c.Product.ImageUrl
            });
        }

        public async Task<CartItemResponseDto> AddToCartAsync(int userId, CartItemRequestDto dto)
        {
            var existing = await _repo.GetCartItemAsync(userId, dto.ProductId);
            if (existing != null)
            {
                existing.Quantity += dto.Quantity;
                await _repo.UpdateCartItemAsync(existing);
            }
            else
            {
                var newItem = new CartItem
                {
                    UserId = userId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    AddedAt = DateTime.UtcNow
                };
                await _repo.AddCartItemAsync(newItem);
            }

            var updated = await _repo.GetCartItemAsync(userId, dto.ProductId);
            var product = await _productRepo.GetByIdAsync(dto.ProductId);
            return new CartItemResponseDto
            {
                CartItemId = updated!.CartItemId,
                ProductId = product!.ProductId,
                ProductName = product.Name,
                Quantity = updated.Quantity!.Value,
                UnitPrice = product.Price
            };
        }

        public async Task<CartItemResponseDto?> UpdateCartItemAsync(int cartItemId, int newQuantity)
        {
            var existing = await _repo.GetCartItemsByUserIdAsync(cartItemId);
            var cartItem = existing.FirstOrDefault(c => c.CartItemId == cartItemId);
            if (cartItem == null) return null;

            cartItem.Quantity = newQuantity;
            var updated = await _repo.UpdateCartItemAsync(cartItem);

            return new CartItemResponseDto
            {
                CartItemId = updated!.CartItemId,
               
                Quantity = updated.Quantity!.Value,
               
            };
        }

        public async Task<bool> RemoveFromCartAsync(int cartItemId)
        {
            return await _repo.RemoveCartItemAsync(cartItemId);
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            return await _repo.ClearCartAsync(userId);
        }
    }
}

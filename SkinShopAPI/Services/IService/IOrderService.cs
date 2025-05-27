using SkinShopAPI.DTOs;

namespace SkinShopAPI.Services.IService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId);
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<OrderDto> UpdateAsync(int id, OrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

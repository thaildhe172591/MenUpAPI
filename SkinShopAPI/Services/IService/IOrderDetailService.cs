using SkinShopAPI.DTOs;

namespace SkinShopAPI.Services.IService
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAllAsync();
        Task<OrderDetailDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetailDto>> GetByOrderIdAsync(int orderId);
        Task<OrderDetailDto> CreateAsync(CreateOrderDetailDto dto);
        Task<OrderDetailDto> UpdateAsync(int id, OrderDetailDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

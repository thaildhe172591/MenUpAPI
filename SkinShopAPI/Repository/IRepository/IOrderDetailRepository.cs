using SkinShopAPI.Models;

namespace SkinShopAPI.Repository.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
        Task<OrderDetail> AddAsync(OrderDetail orderDetail);
        Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
        Task<bool> DeleteAsync(int id);
    }
}

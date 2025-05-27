using SkinShopAPI.Models;

namespace SkinShopAPI.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
    }


}

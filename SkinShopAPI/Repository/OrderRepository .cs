using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;

namespace SkinShopAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SkincareShopForMenContext _context;
        public OrderRepository(SkincareShopForMenContext context)
        {
            _context = context;
        }

       public async Task<IEnumerable<Order>> GetAllAsync()
            => await _context.Orders.Include(o => o.OrderDetails).Include(o => o.Payments).ToListAsync();

        public async Task<Order?> GetByIdAsync(int id)
            => await _context.Orders.Include(o => o.OrderDetails).Include(o => o.Payments).FirstOrDefaultAsync(o => o.OrderId == id);

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
            => await _context.Orders.Where(o => o.UserId == userId).ToListAsync();

        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

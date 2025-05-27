using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using System;

namespace SkinShopAPI.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly SkincareShopForMenContext _context;

        public OrderDetailRepository(SkincareShopForMenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
            => await _context.OrderDetails.ToListAsync();

        public async Task<OrderDetail?> GetByIdAsync(int id)
            => await _context.OrderDetails.FindAsync(id);

        public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
            => await _context.OrderDetails.Where(x => x.OrderId == orderId).ToListAsync();

        public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null) return false;

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

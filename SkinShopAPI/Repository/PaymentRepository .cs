using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;

namespace SkinShopAPI.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SkincareShopForMenContext _context;

        public PaymentRepository(SkincareShopForMenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
            => await _context.Payments.ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id)
            => await _context.Payments.FindAsync(id);

        public async Task<Payment> AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _repository.GetAllAsync();
            return payments.Select(p => new PaymentDto
            {
                PaymentId = p.PaymentId,
                OrderId = p.OrderId,
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus
            });
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new PaymentDto
            {
                PaymentId = p.PaymentId,
                OrderId = p.OrderId,
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus
            };
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = "Pending"
            };

            var created = await _repository.AddAsync(payment);

            return new PaymentDto
            {
                PaymentId = created.PaymentId,
                OrderId = created.OrderId,
                PaymentDate = created.PaymentDate,
                Amount = created.Amount,
                PaymentMethod = created.PaymentMethod,
                PaymentStatus = created.PaymentStatus
            };
        }

        public async Task<PaymentDto> UpdateAsync(int id, PaymentDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Payment not found");

            existing.PaymentMethod = dto.PaymentMethod;
            existing.PaymentStatus = dto.PaymentStatus;
            existing.Amount = dto.Amount;

            var updated = await _repository.UpdateAsync(existing);

            return new PaymentDto
            {
                PaymentId = updated.PaymentId,
                OrderId = updated.OrderId,
                PaymentDate = updated.PaymentDate,
                Amount = updated.Amount,
                PaymentMethod = updated.PaymentMethod,
                PaymentStatus = updated.PaymentStatus
            };
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }

}

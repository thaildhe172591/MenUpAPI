using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;

        public OrderDetailService(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return data.Select(x => new OrderDetailDto
            {
                OrderDetailId = x.OrderDetailId,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            });
        }

        public async Task<OrderDetailDto?> GetByIdAsync(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return null;

            return new OrderDetailDto
            {
                OrderDetailId = x.OrderDetailId,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            };
        }

        public async Task<IEnumerable<OrderDetailDto>> GetByOrderIdAsync(int orderId)
        {
            var data = await _repository.GetByOrderIdAsync(orderId);
            return data.Select(x => new OrderDetailDto
            {
                OrderDetailId = x.OrderDetailId,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            });
        }

        public async Task<OrderDetailDto> CreateAsync(CreateOrderDetailDto dto)
        {
            var newEntity = new OrderDetail
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };
            var created = await _repository.AddAsync(newEntity);

            return new OrderDetailDto
            {
                OrderDetailId = created.OrderDetailId,
                OrderId = created.OrderId,
                ProductId = created.ProductId,
                Quantity = created.Quantity,
                UnitPrice = created.UnitPrice
            };
        }

        public async Task<OrderDetailDto> UpdateAsync(int id, OrderDetailDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("OrderDetail not found");

            existing.ProductId = dto.ProductId;
            existing.Quantity = dto.Quantity;
            existing.UnitPrice = dto.UnitPrice;

            var updated = await _repository.UpdateAsync(existing);

            return new OrderDetailDto
            {
                OrderDetailId = updated.OrderDetailId,
                OrderId = updated.OrderId,
                ProductId = updated.ProductId,
                Quantity = updated.Quantity,
                UnitPrice = updated.UnitPrice
            };
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}

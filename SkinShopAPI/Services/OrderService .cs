using Org.BouncyCastle.Crypto;
using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;
using System;

namespace SkinShopAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Select(MapToDto);
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            return order is null ? null : MapToDto(order);
        }

        public async Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId)
        {
            var orders = await _repository.GetByUserIdAsync(userId);
            return orders.Select(MapToDto);
        }

        public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                ShippingAddress = dto.ShippingAddress,
                Status = "Pending",
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0 // Khởi tạo mặc định, bạn có thể tính toán lại sau nếu có chi tiết
            };

            var created = await _repository.AddAsync(order);
            return MapToDto(created);
        }

        public async Task<OrderDto> UpdateAsync(int id, OrderDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Order not found");

            existing.Status = dto.Status;
            existing.ShippingAddress = dto.ShippingAddress;
            existing.TotalAmount = dto.TotalAmount;

            var updated = await _repository.UpdateAsync(existing);
            return MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);

        // ✳ Tự viết phương thức ánh xạ entity -> DTO
        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId ?? 0,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount ?? 0,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            };
        }
    }
}

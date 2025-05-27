using SkinShopAPI.DTOs;

namespace SkinShopAPI.Services.IService
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto?> GetByIdAsync(int id);
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
        Task<PaymentDto> UpdateAsync(int id, PaymentDto dto);
        Task<bool> DeleteAsync(int id);
    }

}

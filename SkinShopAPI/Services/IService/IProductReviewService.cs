using SkinShopAPI.DTOs;

namespace SkinShopAPI.Services.IService
{
    public interface IProductReviewService
    {
        Task<IEnumerable<ProductReviewDto>> GetAllAsync();
        Task<ProductReviewDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProductReviewDto>> GetByProductIdAsync(int productId);
        Task<ProductReviewDto> CreateAsync(CreateProductReviewDto dto);
        Task<ProductReviewDto> UpdateAsync(int id, ProductReviewDto dto);
        Task<bool> DeleteAsync(int id);
        Task<double?> GetAverageRatingAsync(int productId);
    }
}

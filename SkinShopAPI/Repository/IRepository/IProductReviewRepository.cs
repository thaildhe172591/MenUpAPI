using SkinShopAPI.Models;

namespace SkinShopAPI.Repository.IRepository
{
    public interface IProductReviewRepository
    {
        Task<IEnumerable<ProductReview>> GetAllAsync();
        Task<ProductReview?> GetByIdAsync(int id);
        Task<IEnumerable<ProductReview>> GetByProductIdAsync(int productId);
        Task<ProductReview> AddAsync(ProductReview review);
        Task<ProductReview> UpdateAsync(ProductReview review);
        Task<bool> DeleteAsync(int id);
        Task<double?> GetAverageRatingAsync(int productId);
    }
}

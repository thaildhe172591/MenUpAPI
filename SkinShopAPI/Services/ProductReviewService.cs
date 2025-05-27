using SkinShopAPI.DTOs;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;
using System;

namespace SkinShopAPI.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _repository;


        public ProductReviewService(IProductReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductReviewDto>> GetAllAsync()
        {
            var reviews = await _repository.GetAllAsync();
            return reviews.Select(r => new ProductReviewDto
            {
                ReviewId = r.ReviewId,
                ProductId = r.ProductId,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate
            });
        }

        public async Task<ProductReviewDto?> GetByIdAsync(int id)
        {
            var r = await _repository.GetByIdAsync(id);
            return r is null ? null : new ProductReviewDto
            {
                ReviewId = r.ReviewId,
                ProductId = r.ProductId,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate
            };
        }

        public async Task<IEnumerable<ProductReviewDto>> GetByProductIdAsync(int productId)
        {
            var reviews = await _repository.GetByProductIdAsync(productId);
            return reviews.Select(r => new ProductReviewDto
            {
                ReviewId = r.ReviewId,
                ProductId = r.ProductId,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewDate = r.ReviewDate
            });
        }

        public async Task<ProductReviewDto> CreateAsync(CreateProductReviewDto dto)
        {
            var r = new ProductReview
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                ReviewDate = DateTime.UtcNow
            };
            var created = await _repository.AddAsync(r);
            return new ProductReviewDto
            {
                ReviewId = created.ReviewId,
                ProductId = created.ProductId,
                UserId = created.UserId,
                Rating = created.Rating,
                Comment = created.Comment,
                ReviewDate = created.ReviewDate
            };
        }

        public async Task<ProductReviewDto> UpdateAsync(int id, ProductReviewDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Review not found");

            existing.Rating = dto.Rating;
            existing.Comment = dto.Comment;

            var updated = await _repository.UpdateAsync(existing);
            return new ProductReviewDto
            {
                ReviewId = updated.ReviewId,
                ProductId = updated.ProductId,
                UserId = updated.UserId,
                Rating = updated.Rating,
                Comment = updated.Comment,
                ReviewDate = updated.ReviewDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
        public async Task<double?> GetAverageRatingAsync(int productId)
        {
            return await _repository.GetAverageRatingAsync(productId);
        }
    }
}

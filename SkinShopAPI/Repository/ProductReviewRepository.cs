using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using System;

namespace SkinShopAPI.Repository
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly SkincareShopForMenContext _context;


       public ProductReviewRepository(SkincareShopForMenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync()
            => await _context.ProductReviews.ToListAsync();

        public async Task<ProductReview?> GetByIdAsync(int id)
            => await _context.ProductReviews.FindAsync(id);

        public async Task<IEnumerable<ProductReview>> GetByProductIdAsync(int productId)
            => await _context.ProductReviews
                            .Where(r => r.ProductId == productId)
                            .ToListAsync();

        public async Task<ProductReview> AddAsync(ProductReview review)
        {
            _context.ProductReviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<ProductReview> UpdateAsync(ProductReview review)
        {
            _context.ProductReviews.Update(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _context.ProductReviews.FindAsync(id);
            if (review == null) return false;

            _context.ProductReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<double?> GetAverageRatingAsync(int productId)
        {
            return await _context.ProductReviews
            .Where(r => r.ProductId == productId && r.Rating != null)
            .AverageAsync(r => (double?)r.Rating);
        }
    }
}

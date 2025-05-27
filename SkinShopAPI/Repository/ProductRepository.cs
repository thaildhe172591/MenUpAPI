using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using System;

namespace SkinShopAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SkincareShopForMenContext _context;
        public ProductRepository(SkincareShopForMenContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products
                //.Include(p => p.Category)
                //.Include(p => p.Brand)
                .ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products
                //.Include(p => p.Category)
                //.Include(p => p.Brand)
                .FindAsync(id);

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);

        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

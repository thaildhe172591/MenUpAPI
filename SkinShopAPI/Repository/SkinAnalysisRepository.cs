using Microsoft.EntityFrameworkCore;
using SkinShopAPI.Data;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using System;

namespace SkinShopAPI.Repository
{
    public class SkinAnalysisRepository : ISkinAnalysisRepository
    {
        private readonly SkincareShopForMenContext _context;
        public SkinAnalysisRepository(SkincareShopForMenContext context) => _context = context;

        public async Task<IEnumerable<SkinAnalysis>> GetAllAsync() =>
            await _context.SkinAnalyses
                //.Include(p => p.Category)
                //.Include(p => p.Brand)
                .ToListAsync();

        public async Task<SkinAnalysis?> GetByIdAsync(int id) =>
            await _context.SkinAnalyses
                //.Include(p => p.Category)
                //.Include(p => p.Brand)
                .FindAsync(id);

        public async Task AddAsync(SkinAnalysis skinAnalysis)
        {
            await _context.SkinAnalyses.AddAsync(skinAnalysis);
        }

        public void Update(SkinAnalysis skinAnalysis)
        {
            _context.SkinAnalyses.Update(skinAnalysis);

        }

        public void Delete(SkinAnalysis skinAnalysis)
        {
            _context.SkinAnalyses.Remove(skinAnalysis);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IQueryable<Product> GetProductQueryable()
        {
            return _context.Products.AsQueryable();
        }

    }
}

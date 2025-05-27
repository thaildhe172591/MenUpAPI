using SkinShopAPI.Models;

namespace SkinShopAPI.Repository.IRepository
{
    public interface ISkinAnalysisRepository
    {
        Task<IEnumerable<SkinAnalysis>> GetAllAsync();
        Task<SkinAnalysis?> GetByIdAsync(int id);
        Task AddAsync(SkinAnalysis skinAnalysis);
        void Update(SkinAnalysis skinAnalysis);
        void Delete(SkinAnalysis skinAnalysis);
        Task SaveChangesAsync();
        IQueryable<Product> GetProductQueryable();

    }
}

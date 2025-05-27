using SkinShopAPI.Models;

namespace SkinShopAPI.Services.IService
{
    public interface ISkinAnalysisService
    {
        Task<IEnumerable<SkinAnalysis>> GetSkinAnalysisAsync();
        Task<SkinAnalysis?> GetSkinAnalysisByIdAsync(int id);
        Task AddSkinAnalysisAsync(SkinAnalysis skinAnalysis);
        Task UpdateSkinAnalysisAsync(SkinAnalysis skinAnalysis);
        Task DeleteSkinAnalysisAsync(int id);
        Task<IEnumerable<Product>> SuggestProductsFromAnalysisAsync(object analysisResult);
    }
}
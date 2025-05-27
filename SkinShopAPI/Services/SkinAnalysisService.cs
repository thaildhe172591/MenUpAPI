using System.Text.Json;
using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;
using Microsoft.EntityFrameworkCore;


namespace SkinShopAPI.Services
{
    public class SkinAnalysisService : ISkinAnalysisService
    {
        private readonly ISkinAnalysisRepository _repo;
        public SkinAnalysisService(ISkinAnalysisRepository repo) => _repo = repo;

        public async Task<IEnumerable<SkinAnalysis>> GetSkinAnalysisAsync() => await _repo.GetAllAsync();

        public async Task<SkinAnalysis?> GetSkinAnalysisByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddSkinAnalysisAsync(SkinAnalysis skinAnalysis)
        {
            await _repo.AddAsync(skinAnalysis);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateSkinAnalysisAsync(SkinAnalysis skinAnalysis)
        {
            _repo.Update(skinAnalysis);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteSkinAnalysisAsync(int id)
        {
            var SkinAnalysis = await _repo.GetByIdAsync(id);
            if (SkinAnalysis != null)
            {
                _repo.Delete(SkinAnalysis);
                await _repo.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> SuggestProductsFromAnalysisAsync(object analysisResult)
        {
            var result = JsonSerializer.Serialize(analysisResult);
            using var doc = JsonDocument.Parse(result);
            var root = doc.RootElement.GetProperty("result");

            var skinType = root.GetProperty("skin_type").GetProperty("skin_type").GetInt32();

            bool hasAcne = root.GetProperty("acne").GetProperty("rectangle").GetArrayLength() > 0;
            bool hasDarkCircle = root.GetProperty("dark_circle").GetProperty("value").GetInt32() >= 2;
            bool hasPores = root.GetProperty("pores_forehead").GetProperty("value").GetInt32() >= 1;

            var query = _repo.GetProductQueryable();

            var finalQuery = query.Where(p => false); // Bắt đầu với tập rỗng để dùng Union

            // Gợi ý theo loại da
            if (skinType == 0) // Da khô
            {
                finalQuery = finalQuery.Union(query.Where(p =>
                    (p.Description != null && p.Description.ToLower().Contains("moisturizing")) ||
                    (p.CategoryId == 3) // kem dưỡng
                ));
            }
            else if (skinType == 3) // Da dầu
            {
                finalQuery = finalQuery.Union(query.Where(p =>
                    (p.Description != null && (p.Description.ToLower().Contains("oil control") || p.Description.ToLower().Contains("sebum"))) ||
                    (p.CategoryId == 2) // toner kiềm dầu
                ));
            }

            // Gợi ý theo tình trạng mụn
            if (hasAcne)
            {
                finalQuery = finalQuery.Union(query.Where(p =>
                    p.CategoryId == 11 || p.CategoryId == 1 || p.CategoryId == 3 // trị mụn, srm, kem dưỡng
                ));
            }

            // Gợi ý cho quầng thâm mắt
            if (hasDarkCircle)
            {
                finalQuery = finalQuery.Union(query.Where(p =>
                    (p.Description != null && p.Description.ToLower().Contains("mắt")) ||
                    (p.Name != null && p.Name.ToLower().Contains("eye") || p.Name.ToLower().Contains("mắt")) ||
                    (p.CategoryId == 5) // kem dưỡng da (kem mắt)
                ));
            }

            // Gợi ý cho lỗ chân lông
            if (hasPores)
            {
                finalQuery = finalQuery.Union(query.Where(p =>
                    (p.Description != null && p.Description.ToLower().Contains("pore")) ||
                    (p.CategoryId == 6) // toner se khít
                ));
            }

            return await finalQuery
                .Distinct()
                .Take(12)
                .ToListAsync();
        }
    }
}

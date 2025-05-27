using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> GetProductsAsync() => await _repo.GetAllAsync();

        public async Task<Product?> GetProductByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddProductAsync(Product product)
        {
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _repo.Update(product);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product != null)
            {
                _repo.Delete(product);
                await _repo.SaveChangesAsync();
            }
        }
    }
}

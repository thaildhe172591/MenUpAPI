using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Category>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Category?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Category> AddAsync(Category category) => _repository.AddAsync(category);

        public Task UpdateAsync(Category category) => _repository.UpdateAsync(category);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }

}

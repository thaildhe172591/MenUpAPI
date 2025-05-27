using SkinShopAPI.Models;
using SkinShopAPI.Repository.IRepository;
using SkinShopAPI.Services.IService;

namespace SkinShopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllAsync();

        public Task<User?> GetUserByIdAsync(int id) => _userRepository.GetByIdAsync(id);

        public Task<User> CreateUserAsync(User user) => _userRepository.AddAsync(user);

        public Task UpdateUserAsync(User user) => _userRepository.UpdateAsync(user);

        public Task DeleteUserAsync(int id) => _userRepository.DeleteAsync(id);
    }
}

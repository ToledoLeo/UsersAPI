using UsersAPI.Core.Entities;
using UsersAPI.Core.Interfaces.Repositories;
using UsersAPI.Core.Interfaces.Services;
using UsersAPI.Core.Models.Requests;

namespace UsersAPI.Core.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUser(NewUserRequest request)
        {
            var user = new User()
            {
                Email = request.Email
            };
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var result = await _userRepository.AddAsync(user);
            return result;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await _userRepository.GetUserByLogin(login);
            var senhaCorreta = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (senhaCorreta)
                return user;

            return null;
        }

        public Task<bool> UpdateUser(User user)
        {
            var result = _userRepository.UpdateAsync(user);
            return result;
        }
    }
}

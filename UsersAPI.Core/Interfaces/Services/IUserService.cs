using UsersAPI.Core.Entities;
using UsersAPI.Core.Models.Requests;

namespace UsersAPI.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> AddUser(NewUserRequest request);
        Task<IList<User>> GetAllUsers();
        Task<User> GetUserByLoginAndPassword(string login, string password);
        Task<bool> UpdateUser(User user);
    }
}

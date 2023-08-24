using UsersAPI.Core.Entities;

namespace UsersAPI.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByLogin(string login);
    }
}

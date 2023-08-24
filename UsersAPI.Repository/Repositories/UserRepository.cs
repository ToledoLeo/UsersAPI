using Dapper;
using Microsoft.Extensions.Configuration;
using UsersAPI.Core.Entities;
using UsersAPI.Core.Interfaces.Repositories;

namespace UsersAPI.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabaseConnection _databaseConnection;

        public UserRepository(IConfiguration configuration, IDatabaseConnection databaseConnection) : base(configuration, databaseConnection)
        {
            _configuration = configuration;
            _databaseConnection = databaseConnection;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var query = "SELECT TOP 1 * FROM Users WHERE login = @login";
                var parameters = new { login };
                var result = await connection.QueryAsync<User>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

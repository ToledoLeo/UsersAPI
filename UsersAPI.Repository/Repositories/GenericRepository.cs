using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using UsersAPI.Core.Interfaces.Repositories;

namespace UsersAPI.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabaseConnection _databaseConnection;

        public GenericRepository(IConfiguration configuration, IDatabaseConnection databaseConnection)
        {
            _configuration = configuration;
            _databaseConnection = databaseConnection;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var result = await connection.InsertAsync(entity);
                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var entity = await connection.GetAsync<TEntity>(id);
                return await connection.DeleteAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                return (await connection.GetAllAsync<TEntity>()).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                return await connection.GetAsync<TEntity>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                using var connection = _databaseConnection.GetConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                return await connection.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

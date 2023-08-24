using System.Data;
using System.Data.SqlClient;
using UsersAPI.Core.Interfaces.Repositories;

namespace UsersAPI.Repository.Configuration
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

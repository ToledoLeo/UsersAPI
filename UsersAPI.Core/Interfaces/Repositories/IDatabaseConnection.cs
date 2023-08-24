using System.Data;

namespace UsersAPI.Core.Interfaces.Repositories
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection(string connectionString);
    }
}

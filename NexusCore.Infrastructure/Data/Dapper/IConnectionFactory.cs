using System.Data.SqlClient;

namespace NexusCore.Infrastructure.Data.Dapper
{
    public interface IConnectionFactory
    {
        SqlConnection OpenSqlConnection();
    }
}

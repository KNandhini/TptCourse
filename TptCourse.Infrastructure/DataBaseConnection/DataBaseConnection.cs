using System.Data;
using Microsoft.Data.SqlClient;  // Recommended
using Microsoft.Extensions.Options;

namespace TptCourse.Infrastructure.DatabaseConnection
{
    public sealed class DataBaseConnection : IDataBaseConnection
    {
        public DataBaseConnection(IOptions<ConnectionStrings> connectionStrings)
        {
            Connection = new SqlConnection(connectionStrings.Value.DbConnection);
        }

        public IDbConnection Connection { get; }
    }
}

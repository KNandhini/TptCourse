using System.Data;

namespace TptCourse.Infrastructure.DatabaseConnection
{
    public interface IDataBaseConnection
    {
        IDbConnection Connection { get; }
    }
}

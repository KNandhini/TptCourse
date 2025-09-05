using System.Data;

namespace TptCourseApplication.DataBaseConnection
{
    public interface IDataBaseConnection
    {
        IDbConnection Connection { get; }
    }
}

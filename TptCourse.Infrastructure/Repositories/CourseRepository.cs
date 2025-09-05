using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TptCourse.Infrastructure.Constants;
using TptCourse.Infrastructure.DatabaseConnection;
using TptCourse.Infrastructure.Interfaces;
using TptCourse.Domain.Entities;

namespace TptCourse.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDataBaseConnection _db;

        public CourseRepository(IDataBaseConnection db)
        {
            _db = db;
        }

        // GET
        public async Task<IEnumerable<Course>> GetCourseDetails(int? courseId = null)
        {
            if (courseId.HasValue)
            {
                return (await _db.Connection.QueryAsync<Course>(
                    SPNames.SP_GETCOURSEBYID,
                    new { CourseID = courseId },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            else
            {
                return (await _db.Connection.QueryAsync<Course>(
                    SPNames.SP_GETALLCOURSES,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        // INSERT
        public async Task InsertCourse(Course course)
        {
            var parameters = new
            {
                course.CourseName,
                course.CourseCode,
                course.CourseFee,
                course.Status,
                course.CreatedBy
            };

            // ExecuteAsync works perfectly with your current SP
            await _db.Connection.ExecuteAsync(
                SPNames.SP_INSERTCOURSEDETAILS,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // UPDATE
        public async Task UpdateCourse(Course course)
        {
            var parameters = new
            {
                course.CourseID,
                course.CourseName,
                course.CourseCode,
                course.CourseFee,
                course.Status,
                course.ModifiedBy
            };

            await _db.Connection.ExecuteAsync(
                SPNames.SP_UPDATECOURSEDETAILS,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // DELETE
        public async Task DeleteCourse(int courseId)
        {
            await _db.Connection.ExecuteAsync(
                SPNames.SP_DELETECOURSEDETAILS,
                new { CourseID = courseId },
                commandType: CommandType.StoredProcedure);
        }
    }
}

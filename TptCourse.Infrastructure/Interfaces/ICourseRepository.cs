using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Domain.Entities;

namespace TptCourse.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Course.
    /// </summary>
    public interface ICourseRepository
    {
        // Get all courses or a course by ID
        Task<IEnumerable<Course>> GetCourseDetails(int? courseId = null);

        // Insert a new course (no return value)
        Task InsertCourse(Course course);

        // Update an existing course
        Task UpdateCourse(Course course);

        // Delete a course by ID
        Task DeleteCourse(int courseId);
    }
}

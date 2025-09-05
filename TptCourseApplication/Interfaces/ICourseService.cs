using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;

namespace TptCourse.Application.Interfaces
{
    /// <summary>
    /// Interface for Course service operations.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Gets course details by ID (or all if null).
        /// </summary>
        Task<IEnumerable<CourseDto>> GetCourseDetails(int? id);

        /// <summary>
        /// Inserts a new course.
        /// </summary>
        Task<CourseDto> InsertCourse(CourseDto dto);

        /// <summary>
        /// Updates an existing course.
        /// </summary>
        Task UpdateCourse(CourseDto dto);

        /// <summary>
        /// Deletes a course by ID.
        /// </summary>
        Task DeleteCourse(int courseId);
    }
}

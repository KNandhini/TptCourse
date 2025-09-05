using System;

namespace TptCourse.Domain.Entities
{
    /// <summary>
    /// Entity representing the Course Details table in the database.
    /// </summary>
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public decimal? CourseFee { get; set; }
        public string? Status { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

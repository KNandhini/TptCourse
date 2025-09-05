using System;

namespace TptCourse.Application.Dtos
{
    /// <summary>
    /// Data Transfer Object for Course entity.
    /// </summary>
    public class CourseDto
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

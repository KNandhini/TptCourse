using System;

namespace TptCourse.Application.Dtos
{
    /// <summary>
    /// Data Transfer Object for Batch entity.
    /// </summary>
    public class BatchDto
    {
        public int BatchID { get; set; }
        public int CourseID { get; set; }
        public string? BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string? InstructorName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Status { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // New properties for Course details
        public string? CourseName { get; set; }
        public decimal? CourseFee { get; set; }
        public string? CourseStatus { get; set; }
    }
}

using System.Collections.Generic;
using System;
namespace TptCourse.Domain.Entities
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string FatherOrHusbandName { get; set; } = string.Empty;
        public string ContactAddress { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadharNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // ✅ Keep only list
        public List<Education> ListEducationDetails { get; set; } = new List<Education>();

        public string ModeOfAdmission { get; set; } = string.Empty;
        public string CandidateStatus { get; set; } = string.Empty;
        public string IfEmployed_WorkingAt { get; set; } = string.Empty;
        public bool Declaration { get; set; }   // ✅ match DB BIT now
        public string Place { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }

        public string FilePath { get; set; } = string.Empty;
        public string FileNames { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class Education
    {
        public string EducationType { get; set; } = string.Empty;
        public int? YearOfPassing { get; set; } = null;
        public decimal? Percentage { get; set; } = null;
        public string Institution { get; set; } = string.Empty;
    }
}
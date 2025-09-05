using System;

namespace TptCoarse.Application.Dtos
{
    /// <summary>
    /// Data Transfer Object for Application Form entity.
    /// </summary>
    public class ApplicationFormDto
    {
        public int ApplicationID { get; set; }
        public string CandidateName { get; set; }
        public string Sex { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string ContactAddress { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadharNumber { get; set; }
        public string Email { get; set; }

        public int SSLCYearofPassing { get; set; }
        public decimal SSLCPercentage { get; set; }
        public string SSLCInstitution { get; set; }
        public int HSCYearofPassing { get; set; }
        public decimal HSCPercentage { get; set; }
        public string HSCInstitution { get; set; }
        public int DiplomaYearofPassing { get; set; }
        public decimal DiplomaPercentage { get; set; }
        public string DiplomaInstitution { get; set; }
        public int DegreeYearofPassing { get; set; }
        public decimal DegreePercentage { get; set; }
        public string DegreeInstitution { get; set; }

        public int PGYearofPassing { get; set; }
        public decimal PGPercentage { get; set; }
        public string PGInstitution { get; set; }

        public int OtherYearofPassing { get; set; }
        public decimal OtherPercentage { get; set; }
        public string OtherInstitution { get; set; }

        public string ModeOfAdmission { get; set; }
        public string CandidateStatus { get; set; }
        public string IfEmployed_WorkingAt { get; set; }
        public bool Declaration { get; set; }
        public string Place { get; set; }
        public DateTime ApplicationDate { get; set; }

        public string FilePath { get; set; }
        public string FileNames { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

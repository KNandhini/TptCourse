using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;

namespace TptCourse.Application.Interfaces
{
    /// <summary>
    /// Interface for Application service operations.
    /// </summary>
    public interface IApplicationFormService
    {
        /// <summary>
        /// Gets application form details by ID (or all if null).
        /// </summary>
        Task<IEnumerable<ApplicationFormDto>> GetApplicationFormDetails(int? id);

        /// <summary>
        /// Inserts a new application form.
        /// </summary>
        Task<ApplicationFormDto> InsertApplicationForm(ApplicationFormDto dto);

        /// <summary>
        /// Updates an existing application form.
        /// </summary>
        Task UpdateApplicationForm(ApplicationFormDto dto);
    }
}

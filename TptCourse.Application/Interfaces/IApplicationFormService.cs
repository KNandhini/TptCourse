using ApplicationForm.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on ApplicationForm.
    /// </summary>
    public interface IApplicationFormService
    {
        Task<IEnumerable<ApplicationFormDto>> GetApplicationFormDetails(int? id);
        Task<ApplicationFormDto> InsertApplicationForm(ApplicationFormDto applicationFormDto);
        Task UpdateApplicationForm(ApplicationFormDto applicationFormDto);
    }
}

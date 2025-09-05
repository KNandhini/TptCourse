using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Domain.Entities;

namespace TptCourse.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Application.
    /// </summary>
    public interface IApplicationFormRepository
    {
        Task<IEnumerable<Application>> GetApplicationFormDetails(int? id);
        Task<Application> InsertApplicationForm(Application applicationForm);
        Task UpdateApplicationForm(Application applicationForm);
    }
}

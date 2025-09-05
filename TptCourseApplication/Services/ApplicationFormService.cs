using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;
using TptCourse.Application.Interfaces;
using TptCourse.Infrastructure.Interfaces;

// 👇 Add alias for the entity
using DomainApplicationForm = TptCourse.Domain.Entities.Application;

namespace TptCourse.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on ApplicationForm.
    /// </summary>
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFormService"/> class.
        /// </summary>
        /// <param name="applicationFormRepository">The repository for accessing ApplicationForm data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public ApplicationFormService(IApplicationFormRepository applicationFormRepository, IMapper mapper)
        {
            _applicationFormRepository = applicationFormRepository ?? throw new ArgumentNullException(nameof(applicationFormRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ApplicationFormDto>> GetApplicationFormDetails(int? id)
        {
            var applicationForms = await _applicationFormRepository.GetApplicationFormDetails(id);
            return _mapper.Map<IEnumerable<ApplicationFormDto>>(applicationForms);
        }

        /// <inheritdoc/>
        public async Task<ApplicationFormDto> InsertApplicationForm(ApplicationFormDto applicationFormDto)
        {
            var entity = _mapper.Map<DomainApplicationForm>(applicationFormDto);
            var insertedData = await _applicationFormRepository.InsertApplicationForm(entity);

            if (insertedData == null)
            {
                throw new Exception("Application insertion failed.");
            }

            return _mapper.Map<ApplicationFormDto>(insertedData);
        }

        /// <inheritdoc/>
        public async Task UpdateApplicationForm(ApplicationFormDto applicationFormDto)
        {
            var entity = _mapper.Map<DomainApplicationForm>(applicationFormDto);
            await _applicationFormRepository.UpdateApplicationForm(entity);
        }
    }
}

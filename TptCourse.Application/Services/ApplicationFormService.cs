using AutoMapper;
using TptCoarse.Application.Dtos;
using TptCoarse.Application.Interfaces;
using TptCoarse.Domain.Entities;
using TptCoarse.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationForm.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on ApplicationForm.
    /// </summary>
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly IMapper _mapper;

        public ApplicationFormService(IApplicationFormRepository applicationFormRepository, IMapper mapper)
        {
            _applicationFormRepository = applicationFormRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationFormDto>> GetApplicationFormDetails(int? id)
        {
            var applicationForms = await _applicationFormRepository.GetApplicationFormDetails(id);
            return _mapper.Map<IEnumerable<ApplicationFormDto>>(applicationForms);
        }

        public async Task<ApplicationFormDto> InsertApplicationForm(ApplicationFormDto applicationFormDto)
        {
            var entity = _mapper.Map<ApplicationForm>(applicationFormDto);
            var insertedData = await _applicationFormRepository.InsertApplicationForm(entity);

            if (insertedData == null)
            {
                throw new Exception("Application form insertion failed.");
            }

            return _mapper.Map<ApplicationFormDto>(insertedData);
        }

        public async Task UpdateApplicationForm(ApplicationFormDto applicationFormDto)
        {
            var entity = _mapper.Map<ApplicationForm>(applicationFormDto);
            await _applicationFormRepository.UpdateApplicationForm(entity);
        }
    }
}

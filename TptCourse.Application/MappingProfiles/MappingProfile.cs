using AutoMapper;
using ApplicationForm.Application.Dtos;
using ApplicationForm.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationForm.Application.Mappings
{
    /// <summary>
    /// AutoMapper mapping profile for ApplicationForm and ApplicationFormDto.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Define mappings between ApplicationForm and ApplicationFormDto
            CreateMap<ApplicationForm, ApplicationFormDto>().ReverseMap();
        }
    }
}

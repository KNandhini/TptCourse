using AutoMapper;
using TptCourse.Application.Dtos;
using TptCourse.Domain.Entities;
using DomainApplication = TptCourse.Domain.Entities.Application;

namespace TptCourse.Application.Mappings
{
    /// <summary>
    /// AutoMapper mapping profile for Application (Entity) and ApplicationFormDto.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Define mappings between Application (Entity) and ApplicationFormDto
            CreateMap<DomainApplication, ApplicationFormDto>().ReverseMap();
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<EducationDto, Education>().ReverseMap();
        }
    }
}

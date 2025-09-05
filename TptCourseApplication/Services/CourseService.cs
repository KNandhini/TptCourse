using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;
using TptCourse.Application.Interfaces;
using TptCourse.Infrastructure.Interfaces;
using DomainCourse = TptCourse.Domain.Entities.Course;

namespace TptCourse.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on Course.
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CourseDto>> GetCourseDetails(int? id)
        {
            var courses = await _courseRepository.GetCourseDetails(id);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        /// <inheritdoc/>
        public async Task<CourseDto> InsertCourse(CourseDto courseDto)
        {
            var entity = _mapper.Map<DomainCourse>(courseDto);
            // Call repository (no return value)
            await _courseRepository.InsertCourse(entity);

            // Optionally, map any auto-set fields from entity back to DTO
            courseDto.CourseID = entity.CourseID; // may remain 0 if DB auto-generates it

            return courseDto;
        }

        /// <inheritdoc/>
        public async Task UpdateCourse(CourseDto courseDto)
        {
            var entity = _mapper.Map<DomainCourse>(courseDto);
            await _courseRepository.UpdateCourse(entity);
        }

        /// <inheritdoc/>
        public async Task DeleteCourse(int courseId)
        {
            await _courseRepository.DeleteCourse(courseId);
        }
    }
}

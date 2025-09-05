using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TptCourse.Application.Dtos;
using Microsoft.Data.SqlClient;
using System.Net;
using TptCourse.Application.Interfaces;

namespace TptCourse.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on Course.
    /// </summary>
    [Route("api/course")]
    [ApiController]
    // [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public async Task<IActionResult> GetAllCoursees()
        {
            _logger.LogInformation("{MethodName} called", nameof(GetAllCoursees));
            var result = await _courseService.GetCourseDetails(null);
            return result.Any() ? Ok(result) : NoContent();
        }

        // GET: api/course/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            if (id < 1) return BadRequest("Invalid ID");

            var result = await _courseService.GetCourseDetails(id);
            return result.Any() ? Ok(result) : NotFound("Course not found");
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> InsertCourse([FromBody] CourseDto courseDto)
        {
            var created = await _courseService.InsertCourse(courseDto);
            return CreatedAtAction(nameof(GetCourseById), new { id = created.CourseID }, created);
        }

        // PUT: api/course
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDto courseDto)
        {
            if (courseDto.CourseID <= 0) return BadRequest("Invalid Course ID");

            var existing = await _courseService.GetCourseDetails(courseDto.CourseID);
            if (!existing.Any()) return NotFound("Course not found");

            await _courseService.UpdateCourse(courseDto);
            return NoContent();
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (id < 1) return BadRequest("Invalid Course ID");

            var existing = await _courseService.GetCourseDetails(id);
            if (!existing.Any()) return NotFound("Course not found");

            await _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}

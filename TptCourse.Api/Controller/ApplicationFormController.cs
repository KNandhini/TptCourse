using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Data.SqlClient;
using TptCourse.Application.Dtos;
using TptCourse.Application.Interfaces;

namespace TptCourse.Api.Controllers
{
    [Route("api/applicationform")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly ILogger<ApplicationFormController> _logger;
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(ILogger<ApplicationFormController> logger,
                                         IApplicationFormService applicationFormService)
        {
            _logger = logger;
            _applicationFormService = applicationFormService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ApplicationFormDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllApplicationForms()
        {
            _logger.LogInformation("{MethodName} called", nameof(GetAllApplicationForms));
            try
            {
                var result = await _applicationFormService.GetApplicationFormDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ApplicationFormDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetApplicationFormById(int id)
        {
            _logger.LogInformation("{MethodName} called for ID: {Id}", nameof(GetApplicationFormById), id);

            if (id < 1) return BadRequest(new ProblemDetails { Title = "Invalid ID" });

            try
            {
                var result = await _applicationFormService.GetApplicationFormDetails(id);
                var dto = result.FirstOrDefault();

                return dto != null ? Ok(dto) : NotFound(new ProblemDetails { Title = "Application form not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> InsertApplicationForm([FromBody] ApplicationFormDto applicationFormDto)
        {
            _logger.LogInformation("{MethodName} called", nameof(InsertApplicationForm));
            try
            {
                var created = await _applicationFormService.InsertApplicationForm(applicationFormDto);
                return CreatedAtAction(nameof(GetApplicationFormById), new { id = created.ApplicationID }, created);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while saving the application form.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateApplicationForm([FromBody] ApplicationFormDto applicationFormDto)
        {
            _logger.LogInformation("{MethodName} called", nameof(UpdateApplicationForm));

            if (applicationFormDto.ApplicationID <= 0)
                return BadRequest(new ProblemDetails { Title = "Invalid ID" });

            try
            {
                var existing = await _applicationFormService.GetApplicationFormDetails(applicationFormDto.ApplicationID);
                if (!existing.Any())
                    return NotFound(new ProblemDetails { Title = "Application form not found" });

                await _applicationFormService.UpdateApplicationForm(applicationFormDto);
                return NoContent();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while updating the application form.",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TptCourse.Application.Dtos;
using Microsoft.Data.SqlClient;
using System.Net;
using TptCourse.Application.Interfaces;

namespace TptCourse.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on Batch.
    /// </summary>
    [Route("api/batch")]
    [ApiController]
    // [Authorize]
    public class BatchController : ControllerBase
    {
        private readonly ILogger<BatchController> _logger;
        private readonly IBatchService _batchService;

        public BatchController(ILogger<BatchController> logger, IBatchService batchService)
        {
            _logger = logger;
            _batchService = batchService;
        }

        // GET: api/batch
        [HttpGet]
        public async Task<IActionResult> GetAllBatches()
        {
            _logger.LogInformation("{MethodName} called", nameof(GetAllBatches));
            var result = await _batchService.GetBatchDetails(null);
            return result.Any() ? Ok(result) : NoContent();
        }

        // GET: api/batch/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatchById(int id)
        {
            if (id < 1) return BadRequest("Invalid ID");

            var result = await _batchService.GetBatchDetails(id);
            return result.Any() ? Ok(result) : NotFound("Batch not found");
        }

        // POST: api/batch
        [HttpPost]
        public async Task<IActionResult> InsertBatch([FromBody] BatchDto batchDto)
        {
            var created = await _batchService.InsertBatch(batchDto);
            return CreatedAtAction(nameof(GetBatchById), new { id = created.BatchID }, created);
        }

        // PUT: api/batch
        [HttpPut]
        public async Task<IActionResult> UpdateBatch([FromBody] BatchDto batchDto)
        {
            if (batchDto.BatchID <= 0) return BadRequest("Invalid Batch ID");

            var existing = await _batchService.GetBatchDetails(batchDto.BatchID);
            if (!existing.Any()) return NotFound("Batch not found");

            await _batchService.UpdateBatch(batchDto);
            return NoContent();
        }

        // DELETE: api/batch/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            if (id < 1) return BadRequest("Invalid Batch ID");

            var existing = await _batchService.GetBatchDetails(id);
            if (!existing.Any()) return NotFound("Batch not found");

            await _batchService.DeleteBatch(id);
            return NoContent();
        }
    }
}

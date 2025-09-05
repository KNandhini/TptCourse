using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;

namespace TptCourse.Application.Interfaces
{
    /// <summary>
    /// Interface for Batch service operations.
    /// </summary>
    public interface IBatchService
    {
        /// <summary>
        /// Gets batch details by ID (or all if null).
        /// </summary>
        Task<IEnumerable<BatchDto>> GetBatchDetails(int? id);

        /// <summary>
        /// Inserts a new batch and returns the created batch DTO.
        /// </summary>
        Task<BatchDto> InsertBatch(BatchDto dto);

        /// <summary>
        /// Updates an existing batch and returns the updated batch DTO.
        /// </summary>
        Task<BatchDto> UpdateBatch(BatchDto dto);

        /// <summary>
        /// Deletes a batch by ID.
        /// </summary>
        Task DeleteBatch(int batchId);
    }
}

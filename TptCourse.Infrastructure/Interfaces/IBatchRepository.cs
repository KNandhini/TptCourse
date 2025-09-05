using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Domain.Entities;

namespace TptCourse.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Batch.
    /// </summary>
    public interface IBatchRepository
    {
        // Get all batches or a batch by ID
        Task<IEnumerable<Batch>> GetBatchDetails(int? batchId = null);

        // Insert a new batch and return the created batch with BatchID
        Task<Batch> InsertBatch(Batch batch);

        // Update an existing batch and return the updated batch
        Task<Batch> UpdateBatch(Batch batch);

        // Delete a batch by ID
        Task DeleteBatch(int batchId);
    }
}

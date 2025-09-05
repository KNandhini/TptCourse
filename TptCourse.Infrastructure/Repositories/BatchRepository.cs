using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TptCourse.Infrastructure.Constants;
using TptCourse.Infrastructure.DatabaseConnection;
using TptCourse.Infrastructure.Interfaces;
using TptCourse.Domain.Entities;

namespace TptCourse.Infrastructure.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly IDataBaseConnection _db;

        public BatchRepository(IDataBaseConnection db)
        {
            _db = db;
        }

        // GET: All batches or by BatchID
        public async Task<IEnumerable<Batch>> GetBatchDetails(int? batchId = null)
        {
            if (batchId.HasValue)
            {
                return (await _db.Connection.QueryAsync<Batch>(
                    SPNames.SP_GETBATCHBYID,
                    new { BatchID = batchId },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
            else
            {
                return (await _db.Connection.QueryAsync<Batch>(
                    SPNames.SP_GETALLBATCHES,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        // INSERT: Returns the newly created Batch with BatchID
        public async Task<Batch> InsertBatch(Batch batch)
        {
            var parameters = new
            {
                batch.CourseID,
                batch.BatchName,
                batch.StartDate,
                batch.EndDate,
                batch.TotalSeats,
                batch.AvailableSeats,
                batch.InstructorName,
                batch.StartTime,
                batch.EndTime,
                batch.Status,
                batch.CreatedBy
            };

            int newBatchId = await _db.Connection.QuerySingleAsync<int>(
                SPNames.SP_INSERTBATCHDETAILS,
                parameters,
                commandType: CommandType.StoredProcedure);

            batch.BatchID = newBatchId;
            batch.CreatedDate = DateTime.UtcNow;
            return batch;
        }

        // UPDATE: Updates existing batch
        public async Task<Batch> UpdateBatch(Batch batch)
        {
            var parameters = new
            {
                batch.BatchID,
                batch.CourseID,
                batch.BatchName,
                batch.StartDate,
                batch.EndDate,
                batch.TotalSeats,
                batch.AvailableSeats,
                batch.InstructorName,
                batch.StartTime,
                batch.EndTime,
                batch.Status,
                batch.ModifiedBy
            };

            int rowsAffected = await _db.Connection.ExecuteAsync(
                SPNames.SP_UPDATEBATCHDETAILS,
                parameters,
                commandType: CommandType.StoredProcedure);

            if (rowsAffected == 0)
                throw new KeyNotFoundException($"Batch with ID {batch.BatchID} not found.");

            batch.ModifiedDate = DateTime.UtcNow;
            return batch;
        }

        // DELETE: Deletes batch by BatchID
        public async Task DeleteBatch(int batchId)
        {
            int rowsAffected = await _db.Connection.ExecuteAsync(
                SPNames.SP_DELETEBATCHDETAILS,
                new { BatchID = batchId },
                commandType: CommandType.StoredProcedure);

            if (rowsAffected == 0)
                throw new KeyNotFoundException($"Batch with ID {batchId} not found.");
        }
    }
}

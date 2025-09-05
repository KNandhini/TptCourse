using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TptCourse.Application.Dtos;
using TptCourse.Application.Interfaces;
using TptCourse.Infrastructure.Interfaces;
using DomainBatch = TptCourse.Domain.Entities.Batch;

namespace TptCourse.Application.Services
{
    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public BatchService(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository ?? throw new ArgumentNullException(nameof(batchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BatchDto>> GetBatchDetails(int? id)
        {
            var batches = await _batchRepository.GetBatchDetails(id);
            return _mapper.Map<IEnumerable<BatchDto>>(batches);
        }

        public async Task<BatchDto> InsertBatch(BatchDto batchDto)
        {
            var entity = _mapper.Map<DomainBatch>(batchDto);
            var createdBatch = await _batchRepository.InsertBatch(entity);

            // Map back the full created batch to DTO
            return _mapper.Map<BatchDto>(createdBatch);
        }

        public async Task<BatchDto> UpdateBatch(BatchDto batchDto)
        {
            var entity = _mapper.Map<DomainBatch>(batchDto);
            var updatedBatch = await _batchRepository.UpdateBatch(entity);

            // Return updated DTO with ModifiedDate
            return _mapper.Map<BatchDto>(updatedBatch);
        }

        public async Task DeleteBatch(int batchId)
        {
            await _batchRepository.DeleteBatch(batchId);
        }
    }
}

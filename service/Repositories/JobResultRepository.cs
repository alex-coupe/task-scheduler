using Service.DataAccess;
using Service.DataTransfer.JobResult;
using Service.Repositories.Interfaces;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class JobResultRepository : IJobResultRepository
    {
        private readonly DataContext _context;

        public JobResultRepository()
        {
            _context = new DataContext();
        }

        public async Task CreateJobResult(CreateJobResultDTO dto)
        {
            var jobResult = Mapper.MapCreateJobResultToJobResult(dto, _context);
            _context.Results.Add(jobResult);    
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ReadJobResultDTO> GetResultsForJob(int jobId)
        {
            return Mapper.MapJobResultsToReadDTOs(jobId, _context);
        }
    }
}

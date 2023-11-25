using Service.DataAccess;
using Service.DataTransfer.JobResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IJobResultRepository
    {
        public Task CreateJobResult(CreateJobResultDTO jobResult);
        public IEnumerable<ReadJobResultDTO> GetResultsForJob(int jobId);
    }
}

using Service.DataAccess;
using Service.DataTransfer.Job;
using Service.Repositories.Interfaces;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;
        public JobRepository()
        {
            _context = new DataContext();
        }
        public async Task CreateJob(CreateJobDTO dto)
        {
            var job = Mapper.MapCreateJobToJob(dto, _context);
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ReadJobDTO> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadJobDTO> GetJobsByPlatform(int platformId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadJobDTO> GetJobsByStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public void UpdateJob(UpdateJobDTO job)
        {
            throw new NotImplementedException();
        }
    }
}

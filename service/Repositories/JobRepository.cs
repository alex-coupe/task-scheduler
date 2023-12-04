using Microsoft.EntityFrameworkCore;
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
            return Mapper.MapJobsToReadDTOs(_context.Jobs.ToList());
        }

        public IEnumerable<ReadJobDTO> GetJobsByPlatform(int platformId)
        {
            return Mapper.MapJobsToReadDTOs(_context.Jobs.Where(x => x.Platform.Id == platformId).ToList());
        }

        public IEnumerable<ReadJobDTO> GetJobsByStatus(int statusId)
        {
            return Mapper.MapJobsToReadDTOs(_context.Jobs.Where(x => x.Status.Id == statusId).ToList());
        }

        public async Task UpdateJob(UpdateJobDTO job)
        {
            var jobToUpdate = _context.Jobs.FirstOrDefault(x => x.Id == job.Id);
            if (jobToUpdate != null)
            {
                Mapper.MapUpdateJobToJob(job,jobToUpdate);
                _context.Entry(job).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}

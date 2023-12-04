using Service.DataTransfer.Job;

namespace Service.Repositories.Interfaces
{
    public interface IJobRepository
    {
        public IEnumerable<ReadJobDTO> GetAllJobs();
        public IEnumerable<ReadJobDTO> GetJobsByPlatform(int platformId);
        public IEnumerable<ReadJobDTO> GetJobsByStatus(int statusId);
        public Task UpdateJob(UpdateJobDTO job);
        public Task CreateJob(CreateJobDTO job);
    }
}

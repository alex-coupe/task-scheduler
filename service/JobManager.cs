using Microsoft.EntityFrameworkCore;
using service;
using service.DataTransfer;
using Service.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JobManager : IJobManager
    {
        private DataAccess.DataContext _context;
        public JobManager() 
        {
            _context = new DataAccess.DataContext();
        }

        public async Task AddTask(CreateTaskDTO task) 
        {
            var newTask = new DataAccess.Task()
            {
                Name = task.Name,
                Created = task.Created,
                Creator = task.Creator,
                Interval = task.Interval,
                Job = task.Job.ToString(),
                Priority = task.Priority,
                NextRunTime = task.NextRunTime,
            };
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ExistingTaskDTO> GetTasksToRun()
        {
            return _context.Tasks.Where(x => x.NextRunTime == DateTime.Now).Select(x => new ExistingTaskDTO
            {
                Id = x.Id,
                Job = x.Job,
                Created = x.Created,
                Interval = x.Interval,
                LastRunTime = x.LastRunTime,
                Name = x.Name,
                NextRunTime = x.NextRunTime,
                Priority = x.Priority,
                Creator = x.Creator,
            }).OrderBy(x => x.Priority).ToList();
        }
    }
}

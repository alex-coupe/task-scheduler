using service;
using Service.Repositories.Interfaces;

namespace JobRunner
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IJobRepository _jobRepository;
        
        public Worker(ILogger<Worker> logger, IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var jobs = _jobRepository.GetAllJobs();
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                if (!jobs.Any())
                {
                    _logger.LogInformation("No Jobs To Run...");
                }
              
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

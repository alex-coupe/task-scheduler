using service;

namespace JobRunner
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IJobManager _jobManager;
      
        public Worker(ILogger<Worker> logger, IJobManager jobManager)
        {
            _logger = logger;
            _jobManager = jobManager;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                var tasks = _jobManager.GetTasksToRun();
                if (!tasks.Any()) 
                {
                    _logger.LogInformation("No Jobs To Run...");
                }
                foreach (var task in tasks) 
                {
                    _logger.LogInformation("Running Job: {}",task.Job);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

using JobRunner;
using Service.DataAccess;
using Service.Repositories;
using Service.Repositories.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddSingleton<IIntervalRepository, IntervalRepository>();
builder.Services.AddSingleton<IJobRepository, JobRepository>();
builder.Services.AddSingleton<IJobResultRepository, JobResultRepository>();
builder.Services.AddSingleton<IPlatformRepository, PlatformRepository>();
builder.Services.AddSingleton<IStatusRepository, StatusRepository>();

var host = builder.Build();
host.Run();

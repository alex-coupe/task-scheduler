using JobRunner;
using Microsoft.EntityFrameworkCore;
using service;
using Service;
using Service.DataAccess;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IJobManager, JobManager>();

var host = builder.Build();
host.Run();

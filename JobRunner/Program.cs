using JobRunner;
using Microsoft.EntityFrameworkCore;
using service;
using Service;
using Service.DataAccess;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

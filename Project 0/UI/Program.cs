using UI;
using BL;
using DL;
using DL.Entities;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

Log.Information("Program Started. Serilog running.");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("petdb");

DbContextOptions<dbContext> options = new DbContextOptionsBuilder<dbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new dbContext(options);
try
{
    IMenu menu = new MainMenu(new BL.BL(new Repo(context)));
    menu.Start();
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    Log.CloseAndFlush();
}
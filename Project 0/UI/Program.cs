using UI;
using BL;
using DL;
using DL.Entities;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("petdb");

DbContextOptions<dbContext> options = new DbContextOptionsBuilder<dbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new dbContext(options);

IMenu menu = new MainMenu(new BL.BL(new Repo(context)));
menu.Start();
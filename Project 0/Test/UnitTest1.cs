using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using BL;
using DL;
using Model;
using Entity = DL.Entities;

//install Microsoft.EntityFrameworkCore.Sqlite for mocking db

namespace Test
{
    public class UnitTest1
    {
        private readonly DbContextOptions<Entity.dbContext> options;

        private DL.IRepo _repo;

        public UnitTest1()
        {
            // string dbpath = System.IO.File.ReadAllText(@"../UI/appsettings.json");
            // options = new DbContextOptionsBuilder<Entity.dbContext>().UseSqlServer($"{dbpath}").Options;
            // Seed();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName + "/UI/")
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("petdb");

            options = new DbContextOptionsBuilder<Entity.dbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var testcontext = new Entity.dbContext(options);
            
            _repo = new DL.Repo(testcontext);
        }
        
    // private void Seed()
    // {
    //     using(var context = new Entity.dbContext(options))
    //     {
    //         context.Database.EnsureDeleted();
    //         context.Database.EnsureCreated();

    //         context.Cats.AddRange(
    //         );
    //         context.SaveChanges();
    //     }
    // }

        [Fact]
        public void PassingTest1()
        {

            Assert.Equal(4, Rating("benihana"));
        }

        [Fact]
        public void PassingTest2()
        {
            bool answer = Rating("Arbys") < 4;
            Assert.Equal(true, answer);
        }

        [Fact]
        public void PassingTest3()
        {
            bool answer = Rating("ihop") < 4;
            Assert.Equal(false, answer);
        }

        [Fact]
        public void PassingTest4()
        {
            List<Model.Restaurant> restaurants = _repo.GetAllRestaurants();
            Assert.Equal(true, restaurants.Count > 2);
        }
        
        [Fact]
        public void PassingTest5()
        {
            Assert.Equal(0, Rating("Cheddar"));
        }

        [Fact]
        public void PassingTest6()
        {
            List<Model.Review> reviews = _repo.GetReviewsByRestaurant("Arbys");
            Assert.Equal(3, reviews.Count);
        }

        [Fact]
        public void FailingTest1()
        {
            Assert.Equal(3.33, Rating("Arbys"));
        }

        [Fact]
        public void FailingTest2()
        {
            Assert.Equal(3.3, Rating("Ihop"));
        }

        [Fact]
        public void FailingTest3()
        {
            Model.Restaurant obj = _repo.GetRestaurantDetails("");
            Assert.Equal(null, obj);
        }

        [Fact]
        public void FailingTest4()
        {
            Assert.Equal(4, Rating("arbys"));
        }

        public float Rating(string name)
        {
            return _repo.GetRestaurantDetails(name).Rating;
        }
    }
}
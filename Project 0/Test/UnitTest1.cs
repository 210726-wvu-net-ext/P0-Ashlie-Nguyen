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

        private BL.IBL _bl;

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
            
            _bl = new BL.BL(new DL.Repo(testcontext));
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
            Assert.Equal(true, answer);
        }

        [Fact]
        public void PassingTest4()
        {
            List<Model.Restaurant> restaurants = _bl.GetAllRestaurants();
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
            List<Model.Review> reviews = _bl.GetReviewsByRestaurant("Arbys");
            Assert.Equal(true, reviews.Count > 3);
        }

        [Fact]
        public void PassingTest7()
        {
            List<Model.Review> reviewlist = _bl.GetReviewsByRestaurant("arbys");
            Assert.Equal(true, reviewlist.Count > 1);
        }

        [Fact]
        public void PassingTest8()
        {
            List<Model.Review> reviewlist = _bl.GetReviewsByRestaurant("Outback Steakhouse");
            Assert.Equal(1, reviewlist.Count);
        }

        [Fact]
        public void PassingTest9()
        {
            Model.Restaurant newobj = new Model.Restaurant();
            Model.Restaurant emptyobj = _bl.GetRestaurantDetails("");
            Assert.Equal(newobj.Restaurantname, emptyobj.Restaurantname);
        }

        [Fact]
        public void PassingTest10()
        {
            Assert.Equal(true, _bl.GetUser("ashlie").IsAdmin);
        }

        public float Rating(string name)
        {
            return _bl.GetRestaurantDetails(name).Rating;
        }
    }
}
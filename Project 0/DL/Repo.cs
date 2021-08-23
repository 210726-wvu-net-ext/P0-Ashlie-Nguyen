using Model;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class Repo : IRepo
    {
        private dbContext _context;
        public Repo(dbContext context)
        {
            _context = context;
        }

        public Model.Restaurant GetRestaurantDetails(string name)
        {
            Entities.Restaurant Restaurant = _context.Restaurant.FirstOrDefault(
                x => x.Restaurantname == name
            );
            if (Restaurant != null)
            {
                List<Model.Review> reviews = _context.Review.Where(
                        x => x.Restaurantname == Restaurant.Restaurantname
                    ).Select(
                        x => new Model.Review(x.Restaurantname, x.Username, x.Rating, x.Reviewtext)
                    ).ToList();
                if (reviews.Count > 0)
                    return new Model.Restaurant(Restaurant.Restaurantname, Restaurant.Zipcode, 
                        (float)reviews.Average(x => x.Rating));
                else
                    return new Model.Restaurant(Restaurant.Restaurantname, Restaurant.Zipcode);
            }
            else
                return new Model.Restaurant();
        }

        public List<Model.Restaurant> GetAllRestaurants()
        {
            List<Model.Restaurant> R = _context.Restaurant.Select(
                    rest => new Model.Restaurant(rest.Restaurantname, rest.Zipcode)
                ).ToList();
            for (int i = 0; i < R.Count; i++)
            {
                R[i] = GetRestaurantDetails(R[i].Restaurantname);
            }
            return R;
        }
        
        public List<Model.Restaurant> GetRestaurantsByZip(string zip)
        {
            List<Model.Restaurant> R = _context.Restaurant.Where(
                    x => x.Zipcode == zip
                ).OrderByDescending(
                    x => x.Rating
                ).Select(
                    rest => new Model.Restaurant(rest.Restaurantname, rest.Zipcode)
                ).ToList();
            for (int i = 0; i < R.Count; i++)
            {
                R[i] = GetRestaurantDetails(R[i].Restaurantname);
            }
            return R;
        }
        
        public List<Model.Restaurant> GetRestaurantsByRating(float min, float max)
        {
            List<Model.Restaurant> R = _context.Restaurant.Where(
                    x => x.Rating >= min && x.Rating <= max
                ).OrderByDescending(
                    x => x.Rating
                ).Select(
                    rest => new Model.Restaurant(rest.Restaurantname, rest.Zipcode)
                ).ToList();
            for (int i = 0; i < R.Count; i++)
            {
                R[i] = GetRestaurantDetails(R[i].Restaurantname);
            }
            return R;
        }

        public Model.Restaurant AddARestaurant(Model.Restaurant restaurant)
        {
            _context.Restaurant.Add(
                new Entities.Restaurant {
                    CreatedOn = restaurant.CreatedOn,
                    Restaurantname = restaurant.Restaurantname,
                    Zipcode = restaurant.Zipcode,
                    Rating = restaurant.Rating
                }
            );
            _context.SaveChanges();

            return restaurant;
        }

        public Model.User AddAUser(Model.User user)
        {
            _context.User.Add(
                new Entities.User{
                    CreatedOn = user.CreatedOn,
                    Username = user.Username,
                    Password = user.Password,
                    IsAdmin = user.IsAdmin
                }
            );
            _context.SaveChanges();

            return user;
        }

        public Model.Review AddAReview(Model.Review review)
        {
            _context.Review.Add(
                new Entities.Review {
                    CreatedOn = review.CreatedOn,
                    Restaurantname = review.Restaurantname,
                    Username = review.Username,
                    Rating = review.Rating,
                    Reviewtext = review.Reviewtext
                }
            );
            GetRestaurantDetails(review.Restaurantname);
            _context.SaveChanges();

            return review;
        }
        
        public List<Model.Review> GetReviewsByRestaurant(string name)
        {
            return _context.Review.Where(
                x => x.Restaurantname == name
            ).Select(
                x => new Model.Review(x.Restaurantname, x.Username, x.Rating, x.Reviewtext)
            ).ToList();
        }
        
        public List<Model.Review> GetReviewsByUser(string name)
        {
            return _context.Review.Where(
                x => x.Username == name
            ).Select(
                x => new Model.Review(x.Restaurantname, x.Username, x.Rating, x.Reviewtext)
            ).ToList();
        }

        public Model.User GetUser(string name)
        {
            Entities.User foundUser = _context.User
                .FirstOrDefault(cat => cat.Username == name);
            if(foundUser != null)
            {
                return new Model.User(foundUser.Username, foundUser.Password, foundUser.IsAdmin);
            }
            return new Model.User();
        }

        public List<Model.User> GetUsers(string name)
        {
            return _context.User.Where(
                x => x.Username.Contains(name)
            ).Select(
                x => new Model.User(x.Username, x.Password, x.IsAdmin)
            ).ToList();
        }
    }
}
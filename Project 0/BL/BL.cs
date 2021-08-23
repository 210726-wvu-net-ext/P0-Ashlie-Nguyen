using Model;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class BL : IBL // BL implements IBL
    {
        private IRepo _repo; // _repo is a local field for storing data from DL

        public BL(IRepo repo) // constructor
        {
            _repo = repo; // this stores DL object in local field
        }
        
        // all of the following 11 methods are pass through methods
        // parameters from UI are sent to DL
        // return type data is sent back from DL to UI

        public Restaurant GetRestaurantDetails(string name) // this BL method gets a string from UI
        {
            // the string parameter is passed on to DL and a restaurant object is received
            // the restaurant object is then passed back to UI
            return _repo.GetRestaurantDetails(name); 
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }
        
        public List<Restaurant> GetRestaurantsByZip(string zip)
        {
            return _repo.GetRestaurantsByZip(zip);
        }

        public List<Restaurant> GetRestaurantsByRating(float min, float max)
        {
            return _repo.GetRestaurantsByRating(min, max);
        }

        public List<Review> GetReviewsByRestaurant(string name)
        {
            return _repo.GetReviewsByRestaurant(name);
        }

        public List<Review> GetReviewsByUser(string name)
        {
            return _repo.GetReviewsByUser(name);
        }

        public User GetUser(string name)
        {
            return _repo.GetUser(name);
        }
        
        public List<User> GetUsers(string name)
        {
            return _repo.GetUsers(name);
        }

        public Restaurant AddARestaurant(Restaurant restaurant)
        {
            return _repo.AddARestaurant(restaurant);
        }

        public Review AddAReview(Review review)
        {
            return _repo.AddAReview(review);
        }
        
        public User AddAUser(User user)
        {
            return _repo.AddAUser(user);
        }
    }
}
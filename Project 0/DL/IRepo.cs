using Model;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Restaurant GetRestaurantDetails(string name);
        List<Restaurant> GetAllRestaurants();
        List<Restaurant> GetRestaurantsByZip(string zip);
        List<Restaurant> GetRestaurantsByRating(float min, float max);
        
        List<Review> GetReviewsByRestaurant(string name);
        List<Review> GetReviewsByUser(string name);

        User GetUser(string name);
        List<User> GetUsers(string name);

        Restaurant AddARestaurant(Restaurant restaurant);
        Review AddAReview(Review review);
        User AddAUser(User user);
    }
}
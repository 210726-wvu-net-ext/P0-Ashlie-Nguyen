using Model;
using BL;
using System;
using System.Collections.Generic;

namespace UI
{
    /// <summary>
    /// This UI class presents multiple menus and options for the users to navigate 
    /// BL methods are called to get and set SQL data and store the result to model objects
    /// </summary>
    public class MainMenu : IMenu
    {
        private IBL _bl; // this holds methods for getting and setting data
        private User _user = new User(); // this holds the current user
        public MainMenu(IBL bl)
        {
            _bl = bl;
        }

        /// <summary>
        /// First method called in MainMenu
        /// </summary>
        /// <param>
        /// none
        /// </param>
        /// <returns>
        /// void
        /// </returns>
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Select one of the following options:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create account");
                Console.WriteLine("3. Exit");
                string Input = Console.ReadLine();
                switch (Input) {
                    case "1":
                        repeat = false;
                        Login(); // go to Login
                    break;

                    case "2":
                        repeat = false;
                        AddUser(); // go to AddUser
                    break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        repeat = false; // escape the do..while loop
                    break;

                    default:
                        Console.WriteLine("Please input a number from 0 to 2.");
                    break;
                }
            } while (repeat);
        }

        public void Login()
        {
            Console.Write("\nUsername: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();

            Model.User user = _bl.GetUser(Username);
            // check the user-inputted Username and Password for a matching record from the User table
            if (user.Username == Username && user.Password == Password)
            {
                this._user = user; // store the user record as the current user
                Menu(); // go to the Menu
            }
            else if (user.Username == Username)
                Console.WriteLine("Invalid Password"); // validation
            else
                Console.WriteLine("Invalid Username"); // validation
        }

        public void AddUser()
        {
            string Username;
            string Password;
            string stradmin = ""; // this ensures stradmin has a value
            bool admin = false;
            // this creates an object of the User class type from the Model Namespace
            Model.User userToAdd;
            Model.User userUpdated;
            int loginfail = 0;
            
            // Console.Clear();
            Console.WriteLine("\nAdd new user");
            
            do
            {
                do
                {
                    Console.Write("Username: ");
                    Username = Console.ReadLine();
                    Console.Write("Password: ");
                    Password = Console.ReadLine();
                    if (_user.IsAdmin) {
                        // only admins can create other admins
                        Console.Write("Admin? ");
                        stradmin = Console.ReadLine();
                    }
                } while(String.IsNullOrWhiteSpace(Username) && String.IsNullOrWhiteSpace(Password));
                // the while condition verifies that some input is entered for Username and Password

                if (stradmin == "Y" || stradmin == "y" || stradmin == "Yes" || stradmin == "yes" || stradmin == "1" || stradmin == "True" || stradmin == "true" || stradmin == "TRUE")
                    admin = true;
                userToAdd = new Model.User(Username, Password, admin);
                userUpdated = _bl.AddAUser(userToAdd); // this returns an empty User if the User already exists
                if (userUpdated.Username == null) // null if the User already exists
                {
                    Console.WriteLine($"{userToAdd.Username} is already taken. Please enter another username.");
                    loginfail += 1; // count # of failed logins
                    if (loginfail > 2)
                    {
                        Console.WriteLine("You have failed too many times");
                        return;
                    }
                }
            } while (userUpdated.Username == null);

            if (this._user == null) // check if there is no currently logged in user
            {
                this._user = userToAdd; // set the currently logged in user to the newly created user
            }

            Console.WriteLine($"{userToAdd.Username} was successfully added!");
            Menu(); // go to Menu
        }

        public void Menu() {
            bool repeat = true;
            do
            {
                // Console.Clear();
                Console.WriteLine("\nSelect one of the following options:");
                Console.WriteLine("1. Search restaurant (by name, rating, or zip code)");
                Console.WriteLine("2. Add Restaurant");
                if (_user.IsAdmin) {
                    Console.WriteLine("3. Search user");
                    Console.WriteLine("4. Add a new user");
                    Console.WriteLine("5. Logout");
                    Console.WriteLine("6. Exit");
                }
                else
                {
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("4. Logout");
                }
                string Input = Console.ReadLine();
                switch (Input) {
                    case "1":
                        SearchRestaurant();
                        repeat = false;
                    break;

                    case "2":
                        AddRestaurant();
                        // this method will return to the loop when complete
                    break;

                    case "3":
                        if (_user.IsAdmin)
                        {
                            // exception handling
                            try
                            {
                                SearchUser();
                            }
                                catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Goodbye!");
                            repeat = false;
                        }
                    break;

                    case "4":
                        if (_user.IsAdmin)
                        {
                            AddUser();
                            repeat = false;
                        }
                        else
                        {
                            Start();
                            repeat = false;
                        }
                    break;

                    case "5":
                        if (_user.IsAdmin)
                        {
                            Start();
                            repeat = false;
                        }
                        else
                        {
                            Console.WriteLine("Please input a number from 1 to 4.");
                            // non-admins do not have access to this option
                        }
                    break;

                    case "6":
                        if (_user.IsAdmin)
                        {
                            Console.WriteLine("Goodbye!");
                            repeat = false;
                        }
                        else
                        {
                            Console.WriteLine("Please input a number from 1 to 4.");
                            // non-admins do not have access to this option
                        }
                    break;

                    default:
                        if (_user.IsAdmin)
                            Console.WriteLine("Please input a number from 1 to 6.");
                        else
                            Console.WriteLine("Please input a number from 1 to 4.");
                    break;
                }
            } while (repeat);
        }

        public void SearchRestaurant() {
            bool repeat = true;
            do
            {
                // Console.Clear();
                Console.WriteLine("\nSelect one of the following options:");
                Console.WriteLine("1. Search by restaurant name");
                Console.WriteLine("2. Search by restaurant rating");
                Console.WriteLine("3. Search by restaurant zip code");
                Console.WriteLine("4. Return to previous menu");
                Console.WriteLine("5. Exit");
                string Input = Console.ReadLine();
                switch (Input) {
                    case "5":
                        Console.WriteLine("Goodbye!");
                        repeat = false;
                    break;

                    case "1":
                        GetRestaurantDetails();
                    break;

                    case "2":
                        SearchRestaurantsByRating();
                    break;

                    case "3":
                        SearchRestaurantsByZip();
                    break;

                    case "4":
                        repeat = false;
                        Menu();
                    break;

                    default:
                        Console.WriteLine("Please input a number from 0 to 4.");
                    break;
                }
            } while (repeat);
        }

        public void GetRestaurantDetails()
        {
            Console.WriteLine("Enter a restaurant name to search: ");
            string input = Console.ReadLine(); // receive restaurant name from user
            // get restaurant data from SQL server based on user input
            Restaurant restaurant = _bl.GetRestaurantDetails(input);
            if (restaurant.Restaurantname != null) // check there is some data
            {
                // output zip code and rating
                Console.WriteLine("Zip code: {0}  Rating: {1:N1}\n", restaurant.Zipcode, restaurant.Rating);
                // get review data from SQL server related to the restaurant
                List<Review> reviews = _bl.GetReviewsByRestaurant(input);
                if (reviews.Count > 0)
                    Console.WriteLine("Reviews:");
                for (int i = 0; i < reviews.Count; i++) // loop through the reviews
                {
                    // output the rating and username
                    Console.WriteLine("{0} Stars, by {1}",reviews[i].Rating,reviews[i].Username);
                    Console.WriteLine("{0}\n",reviews[i].Reviewtext); // output the comment
                }
                Console.WriteLine("\nAdd a Review?");
                input = Console.ReadLine(); // get user response
                if (input == "Y" || input == "y" || input == "yes")
                    AddReview(restaurant.Restaurantname); // pass in restaurant name
            }
            else
            {
                Console.WriteLine("No restaurant found");
            }
        }

        public void AddReview(string restaurant)
        {
            bool repeat = true;
            int rating;
            string ratingtext;
            string reviewtext;
            do
            {
            Console.Write("Rating: ");
            ratingtext = Console.ReadLine(); // stores the user rating
            Console.Write("Comment: ");
            reviewtext = Console.ReadLine(); // stores the user comment
            repeat = !Int32.TryParse(ratingtext, out rating);
            if (rating > 5 || rating < 1)
                Console.WriteLine("Enter a Rating from 1-5");
            } while(repeat || rating < 1 || rating > 5);

            // create a Review object with restaurant name, user name, rating, and comment initialized
            Review review = new Review(restaurant, _user.Username, rating, reviewtext);
            _bl.AddAReview(review); // this updates the SQL server
        }

        public void SearchRestaurantsByRating()
        {
            string mintext;
            Console.WriteLine("Minimum rating (1-5 scale): ");
            mintext = Console.ReadLine();
            string maxtext;
            Console.WriteLine("Maximum rating (1-5 scale): ");
            maxtext = Console.ReadLine();
            float min = 0f;
            float max = 5f;
            try {
                min = float.Parse(mintext);
                max = float.Parse(maxtext);
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            // get list of restaurants matching min and max filter
            List<Restaurant> restaurants = _bl.GetRestaurantsByRating(min, max);
            if (restaurants.Count > 0)
                Console.WriteLine();
            foreach (Restaurant r in restaurants)
            {
                // output restaurant rating, zip code, and name for each restaurant
                if (r.Rating > 0)
                    Console.WriteLine("Rating: {0:N1}   Zip code: {1}   Name: {2}", r.Rating, r.Zipcode, r.Restaurantname);
                else
                    Console.WriteLine("Rating: ---   Zip code: {0}   Name: {2}", r.Zipcode, r.Restaurantname);
            }
        }

        public void SearchRestaurantsByZip()
        {
            string zip;
            Console.WriteLine("Enter a zip code to search for restaurants: ");
            zip = Console.ReadLine(); // get zip code from user
            // get list of restaurants in zip code
            List<Restaurant> restaurants = _bl.GetRestaurantsByZip(zip);
            if (restaurants.Count > 0)
                Console.WriteLine();
            foreach (Restaurant r in restaurants)
            {
                // output restaurant rating and name for each restaurant
                if (r.Rating > 0)
                    Console.WriteLine("Rating: {0:N1}   Restaurant: {1}", r.Rating, r.Restaurantname);
                else
                    Console.WriteLine("Rating: ---   Restaurant: {0}", r.Restaurantname);
            }
        }
        
        public void AddRestaurant()
        {
            string name;
            Console.Write("Enter a restaurant name to add: ");
            name = Console.ReadLine(); // get restaurant name
            string zip;
            Console.Write("Enter a zip code: ");
            zip = Console.ReadLine(); // get zip code
            // create a restaurant object with name and zip code initialized
            Restaurant restaurant = _bl.AddARestaurant(new Restaurant(name, zip));
            if (restaurant.Restaurantname == null) // null if the Restaurant already exists
                Console.WriteLine($"{restaurant.Restaurantname} already exists. Thanks.");
            else
                Console.WriteLine("{0} added! Yay!", restaurant.Restaurantname);
        }

        public void SearchUser()
        {
            Console.WriteLine("Enter the name of the user to search: ");
            string input = Console.ReadLine(); // get username
            // query User table on SQL server
            User User = _bl.GetUser(input);
            if(User.Username is null) // check the user exists
            {
                Console.WriteLine($"\nNo exact match for '{input}'");
                List<User> users = _bl.GetUsers(input);
                Console.WriteLine("\n{0} results found containing '{1}':",users.Count,input);
                foreach (User user in users)
                {
                    Console.WriteLine("{0}",user.Username);
                }
            }
            else
            {
                Console.WriteLine("{0} found!",User.Username);
            }
        }
    }
}
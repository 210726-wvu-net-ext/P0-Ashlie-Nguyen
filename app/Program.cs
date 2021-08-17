using System;

namespace app
{
    class Program
    {
        List<Restaurant> Restaurants;
        List<Review> Reviews;

        static void Main(string[] args)
        {

            Console.WriteLine("Select one of the following functions:");
            Console.WriteLine("1. Add a new user");
            Console.WriteLine("2. Ability to search user as admin");
            Console.WriteLine("3. Display details of a restaurant for user");
            Console.WriteLine("4. Add reviews to a restaurant as a user");
            Console.WriteLine("5. View details of restaurants as a user");
            Console.WriteLine("6. View reviews of restaurants as a user");
            Console.WriteLine("7. Calculate reviews’ average rating for each restaurant");
            Console.WriteLine("8.  Search restaurant (by name, rating, zip code, etc.");
            string Input = Console.ReadLine();
            switch (Input) {
                case "1":
                    User.Add(); // This calls a method
                    break;
                case "2":
                    User.Search();
                    break;
                case "3":
                    Console.WriteLine("Enter a restaurant name to view details: ");
                    string r = Console.Readline();
                    Console.WriteLine("\n{0}",Resaurants.Find(x => x.name.Contains(r)));
                    break;
                case "4":
                    
                    break;
                case "5":

                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

                    break;
                default:
                    Console.WriteLine("Please input a number from 1 to 8.");
                    break;
            }
        }
    }
}

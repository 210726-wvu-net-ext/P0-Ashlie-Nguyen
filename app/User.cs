using System;

namespace app
{
    class User
    {
        List<string> users;

        public void Add(){
            Console.WriteLine("Enter the user name you wish to add: ");
            users.Add(Console.ReadLine());
        }

        public void Search(){
            Console.WriteLine("Enter the user name you wish to search for: ");
            Console.WriteLine("The following users are a match: {0}",users.Find(Console.ReadLine()));
        }
}

// namespace: Logical separation of Types
//predefined namespace
using System;

// user defined namespace
namespace HelloWorld
{
    // types - class, interface, structs, enums, delegates
    class Program
    {
        //Type members - variables, methods, properties, events, indexers etc...
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to Revature!");
            Console.WriteLine("The current time is " + DateTime.Now);

            Console.WriteLine("Enter something: ");
            string input = Console.ReadLine();

            if(input == "") {
                Console.WriteLine("You entered nothing");
            }
            else {
                Console.WriteLine("You Entered " + input);
            }
        }
    }
}

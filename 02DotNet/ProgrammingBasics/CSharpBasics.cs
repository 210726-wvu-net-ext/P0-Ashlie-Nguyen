using System;
namespace ProgrammingBasics
{
    public static class CSharpBasics
    {
        internal static float Add(float a, float b){
            return a+b;
        }
        internal static void GetCoffee(string selection){
            int cost = 0;
            switch (selection)
            {
                case "1":
                    cost += 25; // ~ cost = cost + 25
                    break;
                case "2":
                    cost += 25;
                    goto case "1";
                case "3":
                    cost += 50;
                    goto case "1";
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
            if(cost != 0){
                
                Console.WriteLine($"Your total amount for this coffee is {cost} cents");
            }
            Console.Write("Thankyou, have a nice day!");
        }
    }
}
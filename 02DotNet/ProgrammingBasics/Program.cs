using System;

namespace ProgrammingBasics
{
    class Program
    {
      
        static void Main(string[] args)
        {
            #region type conversion
            /*long a = 10;
            int b = (long) a; // explicit conversion
            int b = long.Parse(a); // explicit conversion
            int b = Convert.ToInt64(a); // explicit conversion

            int x = int.MaxValue; //2147483647
            short y = (short)x;
            Console.WriteLine(y);*/
            #endregion
            
            //Input();
            // Console.WriteLine("Coffee sizes Press <1> for small, Press <2> for medium, Press <3> for large. \nPlease enter your selection: ");
            // string size = Console.ReadLine();
            // CSharpBasics.GetCoffee(size);
            // Console.WriteLine("---------Factorial problem-------------");
            // Console.Write("Please enter a number" );
            // int num=int.Parse(Console.ReadLine());
            // Console.WriteLine($"The factorial of {num} is {Factorial.CalculateFactorial_Recursive(num)}");

            //Console.WriteLine(args[0]); // reading commandline arguements

            #region Arrays
            //Arrays.SingleDimensional();
            Arrays.ReverseString("Hello");
            Arrays.SingleDimensional();
            Arrays.MultiDimensional();
            Arrays.JaggedArray();
            #endregion
        }
        static void Input(){
            Console.WriteLine("-------Addition Program------------");
            InputA: // code marker for goto statements
            Console.Write(" Please enter a number : ");          
            string _a = Console.ReadLine(); // operand 1
            float a; //converted operand 1 to float
            bool isValid_a= float.TryParse(_a, out a); //Try parse will return true if conversion of string to float is successful
            if(!isValid_a){ // condition check if string to float conversion succeeded
                Console.WriteLine("This is not a valid number, please try again");
                goto InputA; //Jump statements (goto, return, continue, break)
            }
            InputB:
            Console.Write(" Please enter another number for addition : ");
            float b;
            string _b = Console.ReadLine();
            bool isValid_b = float.TryParse(_b, out b);
            if(!isValid_b){
                Console.WriteLine("This is not a valid number, please try again");
                goto InputB;
            }
            Console.Write($"The addition of {a} and {b} is {CSharpBasics.Add(a,b)}");
        }
    }
}

using System;
namespace ProgrammingBasics
{
    public class Arrays
    {
        internal static void SingleDimensional(){
            /*int[] marks; // declaration
            marks = new int[5]; // initialization
            marks[0]=67; // addinig elements
            marks[3]=85;*/
            /*for (int i = 0; i < marks.Length; i++)
            {
               Console.WriteLine(marks[i]);
            }*/
            //int[] marks=new int[]{67,80,54,66,98};
            int[] marks={67,80,54,66,98};
            Console.WriteLine("This array has - {0} elements.",marks.Length);
            Console.WriteLine("This array's rank - {0}.",marks.Rank);
            Array.Sort(marks);
            Array.Reverse(marks);
            foreach(int mark in marks){
                Console.Write(mark + " ");
            }
            Console.WriteLine();
        }
        // 2-D array - write program to iterate a 2 -D
        internal static void MultiDimensional(){
            int[,] matrix = { { 3,2,1 }, { 6,5,4 } };
            for (int i = 0; i < 2; i++) //This iterates the rows
            {
                for (int j = 0; j < 3; j++) // This iterates the columms
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        internal static void JaggedArray(){
            int[][] ja = new int[3][];//intialize row only
            ja[0]=new int[]{1,2,3,4}; // row 1, col = 4
            ja[1]=new int[]{5,6}; // row 2 , col = 2
            ja[2]=new int[]{9,8,7,9,11}; // row 3 , col=5
            Console.WriteLine("Length - {0} and Rank - {1}",ja.Length, ja.Rank);
            for (int i = 0; i < ja.Length; i++)
            {
                 Console.Write($"Row({i})");
                for (int j = 0; j < ja[i].Length; j++)
                {
                    Console.Write($"{ja[i][j]} ");
                }
                Console.WriteLine();
            }

        }
        // How to reverse a string? input - Hello , output - olleh
        internal static void ReverseString(string s){
            char[] charStr = s.ToCharArray(); //converts string to char array
            for (int i=0, j=s.Length-1;i<j;i++,j--)//4,3,2,1,0
            {
                        charStr[i]=s[j];
                        charStr[j]=s[i];
            }
            string reverseStr = new string(charStr);
            Console.WriteLine(reverseStr);
        }
    }
}
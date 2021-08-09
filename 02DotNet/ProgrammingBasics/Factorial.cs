namespace ProgrammingBasics
{
    public class Factorial
    {
        internal static int CalculateFactorial(int n){
            if(n==0){
                return 1;
            }
            int factorial=1;
           for (int i = n; i >=1; i--){ 
               factorial *= i;        
           }
            return factorial;
        }
        internal static int CalculateFactorial_Recursive(int n){
            if(n==0)
                return 1;
            return n * CalculateFactorial_Recursive(n-1); //4,3,2,1,0
        }
    }
}
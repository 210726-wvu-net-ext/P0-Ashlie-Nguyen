using System;

namespace PetManagement
{
    class Program
    {
        static void Main(string[] args)
        {
           CreatePet();
        }
        static void CreatePet(){
            Pet pet1 =new Pet();
           // assign values to the variables
            Console.Write("Please enter your Pet id: ");
            pet1.id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease enter your Pet name: ");
            pet1.name = Console.ReadLine();
            Console.Write("\nPlease enter your Pet date of birth (yyyy/mm/dd): ");
            pet1.dob = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\nPlease enter your Pet's Gender (press <1> for Female and press <0> for male): ");
            string gender = Console.ReadLine();
            if(gender == "0")
                pet1.gender = Gender.Male;
            else if(gender == "1") 
                pet1.gender = Gender.Female;
            else 
                Console.Write("incorrect Gender (press <1> for Female and press <0> for male)");
            // call the method
            string details=pet1.GetDetails();
            Console.Write(details);
        }
    }
}

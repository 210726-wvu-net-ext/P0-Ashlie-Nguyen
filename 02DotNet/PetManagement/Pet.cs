namespace PetManagement
{
    public class Pet
    {
        // 1. variables 
        public int id;
        public string name;
        public System.DateTime dob;
        public Gender gender;
        // 2. Methods
        public string GetDetails(){
           return $" Pet ID: {id}\n Pet name: {name}\n Birthday: {dob.ToShortDateString()}\n Gender: {gender}";
        }
    }
    public enum Gender{
        Male = 0 ,
        Female
    }
}
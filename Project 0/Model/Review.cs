using System;

namespace Model
{
    /// <summary>
    /// Store data from SQL Review table
    /// 2 FK.  Not referenced by other tables.
    /// </summary>
    public class Review
    {
        public Review() {}
        public Review(string restaurantname, string username, int rating, string reviewtext)
        {
            this.CreatedOn = DateTime.Now;
            this.Restaurantname = restaurantname;
            this.Username = username;
            this.Rating = rating;
            this.Reviewtext = reviewtext;
        }

        // All of these properties are actually on the Review table in SQL
        public DateTime CreatedOn {get;set;} 
        public string Restaurantname {get;set;}
        public string Username {get;set;}
        public int Rating {get;set;}
        public string Reviewtext {get;set;}
    }
}
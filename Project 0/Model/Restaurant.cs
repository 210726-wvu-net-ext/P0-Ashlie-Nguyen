using System;
using System.Collections.Generic;

namespace Model
{
    public class Restaurant
    {
        public Restaurant() {}
        public Restaurant(string name, string zip)
        {
            this.CreatedOn = DateTime.Now;
            this.Restaurantname = name;
            this.Zipcode = zip;
            this.Rating = -1f;
        }
        // There are multiple constructors depending on what data is available during initialization
        public Restaurant(string name, string zip, float rating) 
        {
            this.CreatedOn = DateTime.Now;
            this.Restaurantname = name;
            this.Zipcode = zip;
            this.Rating = rating;
        }

        public DateTime CreatedOn {get;set;}
        public string Restaurantname {get;set;}
        public string Zipcode {get;set;}
        public float Rating {get;set;}

        public List<Review> Review {get;set;} // Restaurant table is referenced by the Review table in SQL
    }
}
using System;
using System.Collections.Generic;

namespace Model
{
    public class User
    {
        public User() {}
        public User(string username, string password, bool isadmin)
        {
            this.CreatedOn = DateTime.Now; // Set when record is created
            this.Username = username;
            this.Password = password;
            this.IsAdmin = isadmin;
        }

        public DateTime CreatedOn {get;set;} // These 4 properties are columns on SQL table
        public string Username {get;set;}
        public string Password {get;set;}
        public bool IsAdmin {get;set;}

        public List<Review> Review {get;set;} // the User table is referenced by the Review table in SQL
    }
}
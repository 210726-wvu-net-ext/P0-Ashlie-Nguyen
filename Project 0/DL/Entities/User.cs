using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        // These properties grant access to data regarding a user
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsAdmin { get; set; }

        // This property is a collection of records on the Review table referencing this record in SQL
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

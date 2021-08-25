using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    /// <summary>
    /// Store data from Review table
    /// 2 FK. Not referenced by other tables.
    /// </summary>
    public partial class Review
    {
        // These properties are on the Review table in SQL
        public int ReviewId { get; set; }
        public string Restaurantname { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Reviewtext { get; set; }
        public DateTime CreatedOn { get; set; }

        // These properties are the records referenced by the Foreign Keys on the Review table in SQL
        public virtual Restaurant RestaurantnameNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}

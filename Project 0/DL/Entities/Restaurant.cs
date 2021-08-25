using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    /// <summary>
    /// Store data from Restaurant table
    /// No FK. Referenced by Review table.
    /// </summary>
    public partial class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public string Restaurantname { get; set; }
        public string Zipcode { get; set; }
        public DateTime CreatedOn { get; set; }
        public float? Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}

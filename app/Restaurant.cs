using System;

namespace app
{
    class Restaurant
    {
        public string name;
        public string style;
        public string zip;
        List<Review> reviews;

        float rating = 0f;
        reviews.ForEach(addup(value){
            rating += (float)value.rating;
        });
        float avg = rating / ratings.Count;

        public override string ToString()
        {
            return "Name: " + name + "  Style: " + style + " Zip Code: " + zip + " Rating: " + avg;
        }
    }
}

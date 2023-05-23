using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Models {
    public class Cuisine {
        public Cuisine()
        {
            Restaurants = new List<Restaurant>();
        }
        public string CuisineCode { get; set; }
        public string CssClass { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}

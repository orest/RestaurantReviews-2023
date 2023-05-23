using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Models {
    public class Restaurant {
        public Restaurant() {
            Reviews = new List<RestaurantReview>();
        }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string CuisineCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateCd { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public int PriceRange { get; set; }
        public string ImageUrl { get; set; }
        public Cuisine Cuisine { get; set; }
        
        public List<RestaurantReview> Reviews { get; set; }
    }
}


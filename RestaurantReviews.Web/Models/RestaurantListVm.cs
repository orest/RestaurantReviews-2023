using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Models {
    public class RestaurantListVm {
        
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

        public string WebImageUrl {
            get {
                var url = "/images/not-avail.jpg";
                
                if (!string.IsNullOrWhiteSpace(ImageUrl)) {

                    url = $"/images/restaurants/{RestaurantId}/{ImageUrl}";
                    //url = $"{_configuration["RestaurantImageUrl"]}{RestaurantId}/{ImageUrl}";
                }
                return url;
            }
        }

        public int CountOfReviews { get; set; }
        public double AverageRating { get; set; }

    }
}

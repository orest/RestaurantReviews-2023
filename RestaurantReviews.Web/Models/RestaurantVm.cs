

using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.Web.Models {
    public class RestaurantVm {
        public int RestaurantId { get; set; }
        [Required]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Restaurant Cuisine")]
        public string CuisineCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateCd { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        [Required]
        [Range(1,5)]
        public int PriceRange { get; set; }
        public string ImageUrl { get; set; }


    }
}

using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Models {
    public class HomeVm {
        public HomeVm()
        {
            RestaurantList = new List<RestaurantListVm>();
            Cuisines=new List<Cuisine>();
        }
        public List<RestaurantListVm> RestaurantList { get; set; }
        public List<Cuisine> Cuisines { get; set; }
    }
}

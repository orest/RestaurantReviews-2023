using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Web.Services;

namespace RestaurantReviews.Web.Components {
    public class CuisineFilter : ViewComponent {
        private readonly IRestaurantRepo _restaurantRepo;

        public CuisineFilter(IRestaurantRepo restaurantRepo) {
            _restaurantRepo = restaurantRepo;
        }
        public IViewComponentResult Invoke() {
            var cuisines = _restaurantRepo.CuisinesRetrieve();

            return View(cuisines);
        }
    }
}

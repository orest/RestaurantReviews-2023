using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Web.Models;
using RestaurantReviews.Web.Services;
using System.Diagnostics;
using AutoMapper;
using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantRepo _restaurantRepo;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            IRestaurantRepo restaurantRepo,
            IMapper mapper
            ) {
            _logger = logger;
            _restaurantRepo = restaurantRepo;
            _mapper = mapper;
        }

        public IActionResult Index(string cuisine = null) {
            List<Restaurant> restaurants;
            if (cuisine != null) {
                restaurants = _restaurantRepo.GetRestaurantsByCuisine(cuisine);
            } else {
                restaurants = _restaurantRepo.GetAllRestaurants();
            }

            var listVms = _mapper.Map<List<RestaurantListVm>>(restaurants);
            var vm = new HomeVm() {
                RestaurantList = listVms,
                //Cuisines = _restaurantRepo.CuisinesRetrieve()
            };
            return View(vm);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Web.Models;

namespace RestaurantReviews.Web.Controllers {
    public class PeopleController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person model) {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Models;
using RestaurantReviews.Web.Services;

namespace RestaurantReviews.Web.Controllers {
    public class ReviewsController : Controller {
        private readonly IRestaurantRepo _restaurantRepo;

        public ReviewsController(IRestaurantRepo restaurantRepo) {
            _restaurantRepo = restaurantRepo;
        }
        // GET: ReviewsController/Create
        public ActionResult Create(int restaurantId) {
            var review = new RestaurantReview {
                RestaurantId = restaurantId
            };
            return View(review);
        }

        // POST: ReviewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantReview model) {
            try {
                if (ModelState.IsValid) {
                    model.ReviewDate= System.DateTime.Now;
                    _restaurantRepo.RestaurantReviewCreate(model);

                    return RedirectToAction("Details", "Restaurants", new { id = model.RestaurantId });
                }
                return View(model);
            } catch {
                return View(model);
            }
        }

        // GET: ReviewsController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: ReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: ReviewsController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: ReviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}

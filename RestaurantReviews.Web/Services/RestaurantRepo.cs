using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Data.Context;
using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Services {
    public class RestaurantRepo : IRestaurantRepo {
        private readonly RestaurantContext _context;

        public RestaurantRepo(RestaurantContext context) {
            _context = context;
        }
        public List<Restaurant> GetAllRestaurants() {
            var restaurants = _context.Restaurants
                .Include(p=>p.Reviews)
                .ToList();
            return restaurants;
        }

        public Restaurant GetRestaurantById(int restaurantId) {
            var restaurant = _context.Restaurants.Find(restaurantId);
            return restaurant;
        }

        public RestaurantReview RestaurantReviewCreate(RestaurantReview model)
        {
            _context.RestaurantReviews.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}

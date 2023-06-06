using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Services {
    public interface IRestaurantRepo {
        public List<Restaurant> GetAllRestaurants();
        public Restaurant GetRestaurantById(int id);
        public RestaurantReview RestaurantReviewCreate (RestaurantReview model);

        List<Cuisine> CuisinesRetrieve();
        List<Restaurant> GetRestaurantsByCuisine(string cuisine);
    }
}

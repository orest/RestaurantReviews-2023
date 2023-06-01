using AutoMapper;
using RestaurantReviews.Models;
using RestaurantReviews.Web.Models;

namespace RestaurantReviews.Web.Services {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<RestaurantVm, Restaurant>().ReverseMap();
            CreateMap<Restaurant, RestaurantListVm>()
                .ForMember(p => p.CountOfReviews, s => s.MapFrom(r => r.Reviews.Count))
                .ForMember(p => p.AverageRating, s => s.MapFrom(r => r.Reviews.Any() ? r.Reviews.Average(p => p.Rating) : 0))
                ;


        }
    }
}

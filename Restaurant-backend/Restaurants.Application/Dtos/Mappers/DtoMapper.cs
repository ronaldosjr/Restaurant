using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dtos.Mappers
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<DishDto, Dish>();
            CreateMap<DishDto, Dish>();

            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}

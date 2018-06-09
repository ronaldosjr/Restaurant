using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Common;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services.Interfaces
{
    public interface IRestaurantApplication : ICrudApplication<RestaurantDto, Restaurant> 
    {
        bool IsNameTaken(RestaurantDto dto);
        RestaurantDto GetById(int id);
    }
}

using System.Collections.Generic;
using Restaurants.Application.Dtos;
using Restaurants.Application.Dtos.Common;
using Restaurants.Application.Services.Common;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Entities.Common;

namespace Restaurants.Application.Services.Interfaces
{
    public interface IDishApplication : ICrudApplication<DishDto, Dish> 
    {
        bool IsNameTaken(DishDto dto);
        DishDto GetById(int id);
    }
}

using System.Linq;
using AutoMapper;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Common;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Domain.Services.ValidationServices.Interface;
using Restaurants.Domain.Specification.Restaurant;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Application.Services
{
    public class RestaurantApplication: CrudApplication<RestaurantDto, Restaurant>,IRestaurantApplication
    {
        public RestaurantApplication(
            IConnection connection, 
            IMapper mapper, 
            IRestaurantRepostitory repository, 
            IRestaurantValidationBeforePersist validation) : base(connection, mapper, repository, validation)
        {
        }

        public bool IsNameTaken(RestaurantDto dto) =>
            Repository.Find(new RestaurantNameTakenSpecification(Mapper.Map<Restaurant>(dto))).Any();

        public RestaurantDto GetById(int id) =>
            Mapper.Map<RestaurantDto>(Repository.Get(new RestaurantIdEqualsToSpecification(id)));
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Dtos.Mappers;
using Restaurants.Application.Services;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Services.ValidationServices;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories;

namespace Restaurants.Application.Test.Helpers
{
    public static class ObjectInitiliazer
    {
      
        public static (IDishApplication, IRestaurantApplication) CreateDishApplication()
        {
            var (connection, mapper) = LoadDependencies();
            var repository = new DishRepository(connection);
            var repositoryRestaurant = new RestaurantRepository(connection);

            return
                (new DishApplication(connection, mapper, repository, new DishValidationBeforePersist(repository)),
                    new RestaurantApplication(connection, mapper, repositoryRestaurant,
                        new RestaurantValidationBeforePersist(repositoryRestaurant)));
        }


        public static IRestaurantApplication CreateRestaurantApplication()
        {
            var (connection, mapper) = LoadDependencies();
            var repository = new RestaurantRepository(connection);

            return new RestaurantApplication(connection, mapper, repository, new RestaurantValidationBeforePersist(repository));
        }


        private static (Connection,IMapper) LoadDependencies()
        {
            var builder = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase("restaurant")
                .Options;
            var context = new RestaurantContext(builder);
            var connection = new Connection(context);

            var mapperConfig = new MapperConfiguration(map => { map.AddProfile<DtoMapper>(); });
            var mapper = mapperConfig.CreateMapper();

            return (connection, mapper);
        }
    }

}

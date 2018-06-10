using System.Linq;
using AutoMapper;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services.Common;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Domain.Services.ValidationServices.Interface;
using Restaurants.Domain.Specification.Dish;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Application.Services
{
    public class DishApplication : CrudApplication<DishDto, Dish>, IDishApplication 
    {
        public DishApplication(IConnection connection, 
            IMapper mapper, 
            IDishRepository repository,
            IDishValidationBeforePersist validation) : base(connection, mapper, repository, validation)
        {
        }

        public bool IsNameTaken(DishDto dto) => 
            Repository.Find(new DishNameTakenSpecification(Mapper.Map<Dish>(dto))).Any();

        public DishDto GetById(int id) =>
            Mapper.Map<DishDto>(Repository.Get(new DishIdEqualsToSpecification(id)));
    }
}

using System;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Properties;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Domain.Services.ValidationServices.Interface;
using Restaurants.Domain.Specification.Dish;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Domain.Services.ValidationServices
{
    public class DishValidationBeforePersist : ValidationBeforePersist<Dish>, IDishValidationBeforePersist
    {
        private readonly IDishRepository _repository;

        public DishValidationBeforePersist(IDishRepository repository)
        {
            _repository = repository;
        }

        public override bool CanPersist(Dish entity)
        {
            base.CanPersist(entity);

            if (_repository.Get(new DishNameTakenSpecification(entity)) != null)
                throw new Exception(DomainValidationMessages.DishAlreadyTaken);

            return true;

        }
    }
}

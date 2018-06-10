using System;
using Restaurants.Domain.Properties;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Domain.Services.ValidationServices.Interface;
using Restaurants.Domain.Specification.Restaurant;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Domain.Services.ValidationServices
{
    public class RestaurantValidationBeforePersist : ValidationBeforePersist<Entities.Restaurant>, IRestaurantValidationBeforePersist
    {
        private readonly IRestaurantRepostitory _repository;

        public RestaurantValidationBeforePersist(IRestaurantRepostitory repository)
        {
            _repository = repository;
        }

        public override bool CanPersist(Entities.Restaurant entity)
        {
            base.CanPersist(entity);

            if (_repository.Get(new RestaurantNameTakenSpecification(entity)) != null)
                throw new Exception(DomainValidationMessages.RestaurantAlreadyTaken);

            return true;
        }

    }
}

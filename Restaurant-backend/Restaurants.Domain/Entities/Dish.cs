using System;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Properties;

namespace Restaurants.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public const int NameLength = 255;

        public Dish()
        {

        }

        public Dish(string name, decimal price, Restaurant restaurant )
        {
            Restaurant = restaurant;
            Name = name;
            Price = price;

            if (restaurant != null)
                RestaurantId = Restaurant.Id;

            IsValid();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public sealed override bool IsValid()
        {
            if (RestaurantId ==0)
                throw new Exception(DomainValidationMessages.RestaurantNotInformed);

            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception(DomainValidationMessages.NameCantBeNull);

            if (Name.Trim().Length > NameLength)
                throw new Exception(DomainValidationMessages.NameTooLong);

            if (Price <= 0)
                throw new Exception(DomainValidationMessages.PriceInvalid);

            return true;
        }
    }
}

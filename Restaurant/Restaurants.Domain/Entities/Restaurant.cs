using System;
using System.Collections.Generic;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Properties;

namespace Restaurants.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public const int NameLength = 255;
        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }

        public Restaurant()
        {

        }

        public Restaurant(string name)
        {
            Name = name;

            IsValid();
        }

        public sealed override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception(DomainValidationMessages.NameCantBeNull);

            if (Name.Trim().Length > NameLength)
                throw new Exception(DomainValidationMessages.NameTooLong);

            return true;
        }

      
        
    }
}

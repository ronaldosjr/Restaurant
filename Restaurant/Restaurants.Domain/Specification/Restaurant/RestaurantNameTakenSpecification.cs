using System;
using System.Globalization;
using System.Linq.Expressions;
using Restaurants.Domain.Specification.Common;

namespace Restaurants.Domain.Specification.Restaurant
{
    public class RestaurantNameTakenSpecification : Specification<Entities.Restaurant>
    {
        private readonly Entities.Restaurant _right;


        public RestaurantNameTakenSpecification(Entities.Restaurant right)
        {
            _right = right;
        }

        public override Expression<Func<Entities.Restaurant, bool>> ToExpression()
        {
            return restaurant => 
                restaurant.Name.ToLower(CultureInfo.InvariantCulture)
                    .Equals(_right.Name.ToLower(CultureInfo.InvariantCulture)) 
                && restaurant.Id.Equals(_right.Id);
        }
    }
}

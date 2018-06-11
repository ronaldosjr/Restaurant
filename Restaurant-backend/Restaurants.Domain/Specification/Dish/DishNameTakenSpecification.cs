using System;
using System.Globalization;
using System.Linq.Expressions;
using Restaurants.Domain.Specification.Common;

namespace Restaurants.Domain.Specification.Dish
{
    public class DishNameTakenSpecification : Specification<Entities.Dish>
    {
        private readonly Entities.Dish _right;


        public DishNameTakenSpecification(Entities.Dish right)
        {
            _right = right;
        }
        
        public override Expression<Func<Entities.Dish, bool>> ToExpression()
        {
            return dish => dish.Name.ToLower(CultureInfo.InvariantCulture).Equals(
                _right.Name.ToLower(CultureInfo.InvariantCulture)) 
                           && ((dish.Id != _right.Id) || (_right.Id == 0))
                           && (dish.Restaurant.Id == _right.Restaurant.Id);
        }
    }
}

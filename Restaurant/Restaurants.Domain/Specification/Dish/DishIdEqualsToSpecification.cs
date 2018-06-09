using Restaurants.Domain.Specification.Common;

namespace Restaurants.Domain.Specification.Dish
{
    public class DishIdEqualsToSpecification : IdEqualsToSpecification<Entities.Dish>
    {
        public DishIdEqualsToSpecification(int id) : base(id)
        {
        }
    }
}

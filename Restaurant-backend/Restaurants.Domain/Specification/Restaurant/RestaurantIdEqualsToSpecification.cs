using Restaurants.Domain.Specification.Common;

namespace Restaurants.Domain.Specification.Restaurant
{
    public class RestaurantIdEqualsToSpecification : IdEqualsToSpecification<Entities.Restaurant>
    {
        public RestaurantIdEqualsToSpecification(int id) : base(id)
        {
        }
    }
}

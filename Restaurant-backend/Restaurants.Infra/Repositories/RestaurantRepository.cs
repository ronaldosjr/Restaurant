using Restaurants.Domain.Entities;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Infra.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepostitory
    {
        public RestaurantRepository(IConnection connection) : base(connection)
        {

        }

        
    }
}

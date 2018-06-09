using System;
using System.Collections.Generic;
using System.Text;
using Restaurants.Domain.Entities;
using Restaurants.Infra.Repositories.Common;

namespace Restaurants.Infra.Repositories.Interfaces
{
    public interface IRestaurantRepostitory : IRepository<Restaurant>
    {
    }
}

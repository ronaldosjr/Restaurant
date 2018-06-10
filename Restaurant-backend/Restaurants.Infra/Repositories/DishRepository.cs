using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Specification.Common;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.Infra.Repositories
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(IConnection connection) : base(connection)
        {
        }

        public new IReadOnlyList<Dish> GetAll() => Query().Include(i => i.Restaurant).ToList();

        public new void Add(Dish entity)
        {
            entity.Restaurant = null;
            base.Add(entity);
        }

        public new Dish Get(Specification<Dish> specification) => 
            Query().Include(d => d.Restaurant).Where(specification.ToExpression().Compile()).FirstOrDefault();
        
    }
}

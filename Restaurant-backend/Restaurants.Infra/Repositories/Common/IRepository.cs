using System.Collections.Generic;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Specification.Common;

namespace Restaurants.Infra.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(Specification<T> specification);
        IReadOnlyList<T> GetAll();
        IReadOnlyList<T> Find(Specification<T> specification);
       
    }
}

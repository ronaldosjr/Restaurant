using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities.Common;
using Restaurants.Domain.Specification.Common;
using Restaurants.Infra.Context;

namespace Restaurants.Infra.Repositories.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly DbContext _context;
        
        public BaseRepository(IConnection connection)
        {
            _context = connection.Context();
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity)
        {
            if (_context.ChangeTracker.Entries<T>().All(i => i.Entity.Id != entity.Id))
                _context.Entry(entity).State = EntityState.Modified;
            else
            {
                var alreadyTracked = _context.ChangeTracker.Entries<T>().FirstOrDefault(i => i.Entity.Id == entity.Id)?.Entity;
                if (alreadyTracked != null)
                    _context.Entry((object) alreadyTracked).CurrentValues.SetValues(entity);
            }
                
        } 
        
        public void Delete(T entity) => _context.Set<T>().Remove(_context.Find<T>(entity.Id));

        public T Get(int id) => _context.Set<T>().FirstOrDefault(i => i.Id == id);

        public T Get(Specification<T> specification) => 
            _context.Set<T>().FirstOrDefault(specification.ToExpression());
        
        public IReadOnlyList<T> GetAll() => _context.Set<T>().ToList();
        
        public IReadOnlyList<T> Find(Specification<T> specification) =>
            _context.Set<T>().Where(specification.ToExpression().Compile()).ToList();

        protected IQueryable<T> Query()
            => _context.Set<T>();

    }
}

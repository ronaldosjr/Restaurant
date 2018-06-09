using System;
using System.Linq.Expressions;

namespace Restaurants.Domain.Specification.Common
{
    public abstract class Specification<T> where T: class
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T source)
        {
            var predicate = ToExpression().Compile();
            return predicate(source);
        }

        public Specification<T> And(Specification<T> specification) =>
            new AndSpecification<T>(this, specification);
        
    }



}

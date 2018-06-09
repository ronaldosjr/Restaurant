using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Restaurants.Domain.Specification.Common
{
    public class AndSpecification<T> : Specification<T> where T: class
    {

        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpr = _left.ToExpression();
            var rightExpr = _right.ToExpression();

            var andExpr = Expression.AndAlso(leftExpr.Body, rightExpr.Body);

            return Expression.Lambda<Func<T, bool>>(andExpr, leftExpr.Parameters.Single());

        }

    }
}

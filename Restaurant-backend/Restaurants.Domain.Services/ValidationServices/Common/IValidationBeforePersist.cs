using Restaurants.Domain.Entities.Common;

namespace Restaurants.Domain.Services.ValidationServices.Common
{
    public interface IValidationBeforePersist<TEntity> where TEntity:BaseEntity
    {
        bool CanPersist(TEntity entity);
    }
}

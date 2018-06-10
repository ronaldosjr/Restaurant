using Restaurants.Domain.Entities.Common;

namespace Restaurants.Domain.Services.ValidationServices.Common
{
    public class ValidationBeforePersist<T> : IValidationBeforePersist<T> where T : BaseEntity
    {
        public virtual bool CanPersist(T entity) => entity.IsValid();

    }
}

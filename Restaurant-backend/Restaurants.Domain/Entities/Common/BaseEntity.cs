using System;

namespace Restaurants.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public abstract bool IsValid();
    }
}

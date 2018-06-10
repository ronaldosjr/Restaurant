using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Domain.Entities.Common;
using Restaurants.Infra.Helpers;

namespace Restaurants.Infra.Mapping
{
    public class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Id).HasColumnName(nameof(BaseEntity.Id).ToLower());
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreationDate).HasColumnName(nameof(BaseEntity.CreationDate).ToUnderscoreCase());
        }
    }
}

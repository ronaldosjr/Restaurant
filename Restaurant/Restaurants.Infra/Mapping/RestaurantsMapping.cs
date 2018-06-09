using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Domain.Entities;

namespace Restaurants.Infra.Mapping
{
    public class RestaurantsMapping : BaseEntityMapping<Restaurant>
    {
        public override void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Restaurant).ToLower());
            builder.Property(p => p.Name).HasMaxLength(Restaurant.NameLength).HasMaxLength(Restaurant.NameLength);
        }
    }
}

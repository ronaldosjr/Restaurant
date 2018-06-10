using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Domain.Entities;

namespace Restaurants.Infra.Mapping
{
    public class DishMapping : BaseEntityMapping<Dish>
    {
        public override void Configure(EntityTypeBuilder<Dish> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Dish).ToLower());
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(Dish.NameLength);
            builder.HasOne(p => p.Restaurant).WithMany(r => r.Dishes).HasForeignKey(p => p.RestaurantId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

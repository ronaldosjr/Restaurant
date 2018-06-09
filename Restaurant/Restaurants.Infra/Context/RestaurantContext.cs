using Microsoft.EntityFrameworkCore;
using Restaurants.Infra.Helpers;
using Restaurants.Infra.Mapping;

namespace Restaurants.Infra.Context
{
    public class RestaurantContext : DbContext
    {
        public readonly DbContextOptions<RestaurantContext> Options;

        public RestaurantContext() { }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(
                 "server=localhost;user id=postgres;password=postgres;persistsecurityinfo=True;database=restaurant;Pooling=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestaurantsMapping());
            modelBuilder.ApplyConfiguration(new DishMapping());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                    property.Relational().ColumnName = property.Name.ToUnderscoreCase();
            }

        }
    }
}


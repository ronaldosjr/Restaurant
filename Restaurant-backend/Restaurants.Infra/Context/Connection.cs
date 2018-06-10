using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace Restaurants.Infra.Context
{
    public class Connection : IConnection
    {
        private readonly DbContext _context;

        public Connection(RestaurantContext context)
        {
            _context = context;
            CheckIfMigrationIsRequired(context);
        }

        public DbContext Context() => _context;

        public void Commit() =>_context.SaveChanges();

        private void CheckIfMigrationIsRequired(RestaurantContext context)
        {
            if (context.Options != null)
            {
                if (context.Options.Extensions.OfType<InMemoryOptionsExtension>().Any())
                {
                    return;
                }
            }
           if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();
        }

        
    }
}


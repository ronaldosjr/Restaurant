using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infra.Context
{
    public interface IConnection
    {
        DbContext Context();
        void Commit();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infra.Context;
using Restaurants.Infra.Repositories;
using Restaurants.Infra.Repositories.Common;
using Restaurants.Infra.Repositories.Interfaces;

namespace Restaurants.IoC.Modules
{
    public class RepositoryIoCModule
    {
        public RepositoryIoCModule(IServiceCollection services)
        {
            services.AddScoped<IConnection, Connection>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IRestaurantRepostitory, RestaurantRepository>();

        }
    }
}

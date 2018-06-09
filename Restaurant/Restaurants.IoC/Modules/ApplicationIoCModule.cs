using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Services;
using Restaurants.Application.Services.Common;
using Restaurants.Application.Services.Interfaces;

namespace Restaurants.IoC.Modules
{
    public class ApplicationIoCModule
    {
        public ApplicationIoCModule(IServiceCollection services)
        {
            services.AddScoped<IDishApplication, DishApplication>();
            services.AddScoped<IRestaurantApplication, RestaurantApplication>();

        }
    }
}

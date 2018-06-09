using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Services.ValidationServices;
using Restaurants.Domain.Services.ValidationServices.Common;
using Restaurants.Domain.Services.ValidationServices.Interface;

namespace Restaurants.IoC.Modules
{
    public class DomainIoCModules
    {
        public DomainIoCModules(IServiceCollection services)
        {
            services.AddScoped<IDishValidationBeforePersist, DishValidationBeforePersist>();
            services.AddScoped<IRestaurantValidationBeforePersist, RestaurantValidationBeforePersist>();
        }
    }
}

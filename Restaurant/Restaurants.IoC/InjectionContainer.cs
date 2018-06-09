using System;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.IoC.Modules;

namespace Restaurants.IoC
{
    public static class InjectionContainer
    {
        public static void DoInjection(IServiceCollection services)
        {
            new RepositoryIoCModule(services);
            new DomainIoCModules(services);
            new ApplicationIoCModule(services);
        }
    }
}

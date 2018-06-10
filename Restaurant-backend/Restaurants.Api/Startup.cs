using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurants.Api.Helpers;
using Restaurants.Application.Dtos.Mappers;
using Restaurants.Infra.Context;
using Restaurants.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace Restaurants.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(i => i.Filters.Add(typeof(ValidateModelFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<RestaurantContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("Restaurant")));

            services.AddAutoMapper(s => s.AddProfile(new DtoMapper()));

            InjectionContainer.DoInjection(services);

            services.AddSwaggerGen(c => 
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Gerenciador de Restaurante",
                        Version = "v1",
                        Description = "API do Sistema Gerenciador de Restaurantes",
                        Contact = new Contact
                        {
                            Name = "Ronaldo  Ribeiro",
                            Url = "https://github.com/ronaldosjr/Restaurant"
                        }
                    }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(i => i.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciador de Restaurante"); });
           
        }

        
    }
}

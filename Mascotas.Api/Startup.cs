using Mascotas.Api.Application;
using Mascotas.Api.ApplicationServices;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Filters;
using Mascotas.Api.Domain.Mappers;
using Mascotas.Api.DomainServices;
using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Repositories;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Mascotas.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddDbContext<ApplicationDbContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("ConnectionDefault")));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetDomain, PetDomainService>();
            services.AddScoped<IPetApplication, PetApplicationService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerDomain, OwnerDomainService>();
            services.AddScoped<IOwnerApplication, OwnerApplicationService>();

            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaDomain, AgendaDomainService>();
            services.AddScoped<IAgendaApplication, AgendaApplicationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mascotas.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mascotas.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

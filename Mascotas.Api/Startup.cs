using FluentValidation.AspNetCore;
using Mascotas.Api.Application;
using Mascotas.Api.ApplicationServices;
using Mascotas.Api.Domain;
using Mascotas.Api.Domain.Filters;
using Mascotas.Api.DomainServices;
using Mascotas.Api.Infrastructure.Context;
using Mascotas.Api.Infrastructure.Repositories;
using Mascotas.Api.Infrastructure.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;

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

            services.AddControllers().AddJsonOptions(p =>
                p.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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

            services.AddScoped<ILoginApplication, LoginApplicationService>();
            services.AddScoped<ILoginDomain, LoginDomainService>();

            services.AddScoped<IUserDomain, UserDomainService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRolRepository, RolRepository>();

            services.AddScoped<IVeterinaryRepository, VeterinaryRepository>();
            services.AddScoped<IVeterinaryDomain, VeterinaryDomainServices>();
            services.AddScoped<IVeterinaryApplication, VeterinaryApplicationService>();

            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IHistoryDomain, HistoryDomainService>();
            services.AddScoped<IHistoryApplication, HistoryApplicationService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = false,
                            ValidAudience = Configuration["Jwt:Issuer"],
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mascotas.Api", Version = "v1" });

                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme, new string[] { }
                    }
                });
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

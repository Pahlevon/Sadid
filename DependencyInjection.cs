using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SadidServices.Materials.Application.Coils;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;
using SadidServices.Materials.Application.Contracts;
using SadidServices.Materials.Domain.Coils;
using SadidServices.Materials.Infrastructure.Persistance.Repositories;
using SadidServices.Materials.Infrastructure.Persistence;
using SadidServices.Materials.Infrastructure.Repositories;
using SadidServices.Materials.Infrastructure.Repositories.Services;

namespace SadidServices
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCarter();
            services.AddSingleton<ICoilRepository, CoilRepository>(); //this is how we inject dependancys
            services.AddSingleton<ICoilManager, CoilManager>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddDbContext<CatalogContext>(optionsBuilder =>
            {
                var cnnStr = configuration.GetConnectionString("SadidTest");
                optionsBuilder.UseSqlServer(cnnStr);
                // We are using the connection string from the appsettings.json file
            });
        }

        public static void UseMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapCarter();

        }
    }
}
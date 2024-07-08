using AutoMapper;
using Mercadoria.Infraestructure.Context;
using Mercadorias.Application.InterfacesDTO;
using Mercadorias.Application.Mapping;
using Mercadorias.Application.Services;
using Mercadorias.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadorias.DependencyInjection.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfraestructure (this IServiceCollection services, 
            IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnect")));

            services.AddScoped<IItemRepository, IItemRepository>();
            services.AddScoped<IItemService, ItemService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}

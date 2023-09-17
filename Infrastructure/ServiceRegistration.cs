using Domain.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EFDBContext>(options => options.UseSqlite(Configuration.ConnectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
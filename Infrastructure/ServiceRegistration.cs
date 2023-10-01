using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
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
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<EFDBContext>(options => options.UseSqlite(Configuration.ConnectionString));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<EFDBContext>()
             .AddDefaultTokenProviders();

            services.AddDbContext<EFDBContext>(options => options.UseSqlite(Configuration.ConnectionString));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
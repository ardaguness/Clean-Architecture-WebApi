using Application.Features.Product.ProductCommands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistration
    {
        public class RegisterMapper : Profile
        {
            public RegisterMapper()
            {
                CreateMap<CreateProduct, Category>();
                CreateMap<UpdateProduct, Product>();
            }
        }
        public static void AddMapperServices(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<RegisterMapper>();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}

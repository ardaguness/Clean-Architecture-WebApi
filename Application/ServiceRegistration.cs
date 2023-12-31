﻿using Application.Features.Category.CategoryQueries;
using Application.Features.Product.ProductCommands;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Account.AccountCommands.AccountCommands;

namespace Application
{
    public static class ServiceRegistration
    {
        public class RegisterMapper : Profile
        {
            public RegisterMapper()
            {
                CreateMap<CreateProduct, Product>();
                CreateMap<UpdateProduct, Product>();
                CreateMap<RegisterCommand, RegisterUser>();
                CreateMap<Category, GetCategoriesMapper>();
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

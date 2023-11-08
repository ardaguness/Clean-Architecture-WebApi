using Domain.Entities;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Infrastructure.Contexts;
using Moq;
using Application.Features;
using Infrastructure.Repositories;
using Domain.Interfaces;

namespace WebApi.Tests
{
    public class ProductTests
    {
        public interface IDbContext
        {
            public IList<Product> Products { get; }
        }
        internal class DbContext : IDbContext
        {
            public IList<Product> Products { get; } = new List<Product>();
        }

        //[Fact]
        //public async Task GetAllProductsTest()
        //{
        //    var handler = new AllProductQueriesHandlers(IProductRepository);
        //    var result = await handler.Handle(new GetProducts(), CancellationToken.None);
        //    result.<GetAllTodoListsResponse>();
        //    result.TodoLists.ShouldBeOfType<ReadOnlyCollection<GetAllTodoListsDto>>();
        //    result.TodoLists.Count.ShouldBe(2);
        //}
    }

}


using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class AllProductQueriesHandlers :
       IRequestHandler<GetProducts, GetProductsResponse>,
       IRequestHandler<GetProductById, GetProductByIdResponse>,
       IRequestHandler<GetProductsByCategoryId, GetProductsByCategoryIdResponse>
    {
        readonly IProductRepository _productRepo;

        public AllProductQueriesHandlers(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<GetProductsResponse> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = _productRepo.GetAll().ToList();
            return new() { Products = products };
        }

        public async Task<GetProductByIdResponse> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.ProductId);
            return new() { Product = product };
        }

        public async Task<GetProductsByCategoryIdResponse> Handle(GetProductsByCategoryId request, CancellationToken cancellationToken)
        {
            var products = _productRepo.GetProductsByCategoryId(request.CategoryId);
            return new() { Products = products };
        }
    }
}

using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.ProductQueries
{
    public class AllProductQueriesHandlers :
       IRequestHandler<GetProducts, GetProductsResponse>
    {
        readonly IProductRepository _productRepo;

        public AllProductQueriesHandlers(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<GetProductsResponse> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = _productRepo.GetAll();
            return new() { Products = products };
        }
    }
}

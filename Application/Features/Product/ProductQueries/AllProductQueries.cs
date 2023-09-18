using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.ProductQueries
{
    public class GetProducts : IRequest<GetProductsResponse>
    {

    }
    public class GetProductsResponse
    {
        public object Products { get; set; }
    }
}

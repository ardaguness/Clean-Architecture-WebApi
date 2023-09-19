using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class GetProducts : IRequest<GetProductsResponse>
    {

    }
    public class GetProductsResponse
    {
        public object Products { get; set; }
    }

    public class GetProductById : IRequest<GetProductByIdResponse>
    {
        public string ProductId { get; set; }
    }
    public class GetProductByIdResponse
    {
        public object Product { get; set; }
    }
}

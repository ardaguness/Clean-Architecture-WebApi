using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.OrderQueries
{
    public class GetOrders:IRequest<GetOrdersResponse>
    {
    }
    public class GetOrdersResponse
    {
        public object Orders { get; set; }
    }
}

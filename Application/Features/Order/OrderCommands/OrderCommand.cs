using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.OrderCommands
{
    public class CreateOrder:IRequest<CreateOrderResponse>
    {
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<string> ProductIds { get; set; }
    }
    public class CreateOrderResponse
    {
        public string OrderId { get; set; }
    }
}

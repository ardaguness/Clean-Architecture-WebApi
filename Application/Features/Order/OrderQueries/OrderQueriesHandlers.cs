using Application.Features.Order.OrderCommands;
using Application.Features.Product.ProductCommands;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.OrderQueries
{
    public class OrderQueriesHandlers :
           IRequestHandler<GetOrders, GetOrdersResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderQueriesHandlers(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepository = orderRepo;
            _mapper = mapper;
        }

        public async Task<GetOrdersResponse> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll();
            return new() { Orders = orders };
        }
    }
}

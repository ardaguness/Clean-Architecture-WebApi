using Application.Features.Product.ProductCommands;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.OrderCommands
{
    public class OrderCommandHandlers :
           IRequestHandler<CreateOrder, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderCommandHandlers(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepository = orderRepo;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            return new() { };
        }
    }
}
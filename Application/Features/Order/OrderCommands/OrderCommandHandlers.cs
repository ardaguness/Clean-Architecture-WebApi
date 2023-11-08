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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderCommandHandlers(IOrderRepository orderRepo, IProductRepository productRepo, IMapper mapper)
        {
            _orderRepository = orderRepo;
            _productRepository = productRepo;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByIds(request.ProductIds);

            var order = new Domain.Entities.Order
            {
                CustomerId = request.CustomerId,
                Address = request.Address,
                Description = request.Description,
                Products = products
            };
            await _orderRepository.AddAsync(order);

            return new CreateOrderResponse { OrderId = order.Id };
        }
    }
}
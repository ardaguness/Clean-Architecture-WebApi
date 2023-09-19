using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.ProductCommands
{
    public class AllProductCommandHandlers :
           IRequestHandler<CreateProduct, CreateProductResponse>,
           IRequestHandler<UpdateProduct, UpdateProductResponse>,
           IRequestHandler<DeleteCommand, DeleteCommandResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public AllProductCommandHandlers(IProductRepository productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<DeleteCommandResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _productRepo.RemoveAsync(request.Id);
            return new DeleteCommandResponse();
        }

        public async Task<UpdateProductResponse> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);

            var updatedProduct = _productRepo.Update(product);
            return new UpdateProductResponse();
        }

        public async Task<CreateProductResponse> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _productRepo.AddAsync(product);
            return new CreateProductResponse();
        }
    }
}

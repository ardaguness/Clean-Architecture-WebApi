using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.ProductCommands
{
    public class CreateProduct:IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }

    }
    public class CreateProductResponse
    {
        
    }

    public class UpdateProduct : IRequest<UpdateProductResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;

    }
    public class UpdateProductResponse
    {
        public string ResponseMsg { get; set; }
    }

    public class DeleteCommand : IRequest<DeleteCommandResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteCommandResponse
    {

    }
}

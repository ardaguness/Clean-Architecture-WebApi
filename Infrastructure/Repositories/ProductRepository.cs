using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EFDBContext context) : base(context)
        {
        }
    }
}

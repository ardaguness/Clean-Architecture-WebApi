using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private EFDBContext db;
        public ProductRepository(EFDBContext context) : base(context)
        {
            db = context;
        }

        public async Task<ICollection<Product>> GetProductsByCategoryId(string CategoryId) => await db.Products.Where(i => i.CategoryId == CategoryId).ToListAsync();
        

        public async Task<ICollection<Product>> GetProductsByIds(ICollection<string> productIds) => await db.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
    }
}

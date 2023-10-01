using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order:BaseEntity
    {
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

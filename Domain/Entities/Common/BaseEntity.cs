using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}

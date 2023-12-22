using BaseCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        [Precision(18, 4)]
        public decimal UnitPrice { get; set; }
        public string? SubstituteProductId { get; set; }
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new Collection<CustomerProduct>();

    }
}

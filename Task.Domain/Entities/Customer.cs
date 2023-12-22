using BaseCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Type { get; set; }
        [Precision(18, 4)]
        public decimal? Voiting{ get; set; }
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new Collection<CustomerProduct>();
    }
}

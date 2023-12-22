using BaseCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerProduct:BaseEntity
    {
        [Precision(18, 4)]
        public decimal? UsedPerMounth { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product{ get; set; }
        public virtual Customer Customer{ get; set; }
    }
}

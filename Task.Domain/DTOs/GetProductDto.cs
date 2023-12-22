using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPricePerMounth { get; set; }
        public decimal? TotalUsed{ get; set; }
        public string? SubstituteProductId { get; set; }
        public string? SubstituteProductName { get; set; }


    }
}

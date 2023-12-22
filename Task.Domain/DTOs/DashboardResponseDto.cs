using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class DashboardResponseDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string? Type { get; set; }
        public decimal? Voiting { get; set; }
        public List<GetProductDto> UsedProductsList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Type { get; set; }
        public decimal? Voiting { get; set; }
    }
}

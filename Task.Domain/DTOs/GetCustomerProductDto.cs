using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetCustomerProductDto
    {

        public List<CustomerRequestModel> CustomerList { get; set; }
        public List<ProductRequestModel> ProductList { get; set; }
    }
}

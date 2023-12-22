using Domain.Context;
using Domain.DTOs;
using Domain.Entities;
using BaseCore.Enums;
using Microsoft.EntityFrameworkCore;
using Persistance.Abstracts;
using Persistance.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistance.Repository
{
    public class CustomerProductRepository : Repository<CustomerProduct>, ICustomerProductRepository
    {
        private readonly MyDbContext _context;

        public CustomerProductRepository(MyDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Task<List<DashboardResponseDto>> GetDashboard()
        {
            var data = _context.CustomerProducts
                             .Include(x => x.Product)
                             .Include(x => x.Customer)
                                .Where(x => x.Product.RecordStatus == RecordStatus.Active && x.Customer.RecordStatus == RecordStatus.Active).ToList();
            if (data != null && data.Count > 0)
            {
                
                List<DashboardResponseDto> response = new List<DashboardResponseDto>();
                foreach (var customerProduct in data)
                {

                    DashboardResponseDto model = new DashboardResponseDto
                    {
                        UsedProductsList = new List<GetProductDto>(),
                        Type = customerProduct.Customer.Type,
                        CustomerId = customerProduct.Customer.Id,
                        CustomerName = customerProduct.Customer.Name,
                        CustomerSurname = customerProduct.Customer.Surname,
                        Voiting = customerProduct.Customer.Voiting,
                    };
                    GetProductDto product = new GetProductDto
                    {
                        Name = customerProduct.Product.Name,
                        ProductId = customerProduct.Product.Id,
                        SubstituteProductId = customerProduct.Product.SubstituteProductId,
                        UnitPrice = customerProduct.Product.UnitPrice,
                        UnitPricePerMounth = customerProduct.UsedPerMounth,
                        TotalUsed = customerProduct.Product.UnitPrice * customerProduct.UsedPerMounth
                    };
                    model.UsedProductsList.Add(product);

                    response.Add(model);
                }
                return Task.FromResult(response);
            }







            throw new NotImplementedException();
        }
    }
}

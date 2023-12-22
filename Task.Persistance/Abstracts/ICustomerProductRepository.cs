using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Abstracts
{
    public interface ICustomerProductRepository : IRepository<CustomerProduct>
    {
        Task<List<DashboardResponseDto>> GetDashboard();
    }
}

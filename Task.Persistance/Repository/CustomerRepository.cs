using Domain.Context;
using Domain.Entities;
using Persistance.Abstracts;
using Persistance.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}

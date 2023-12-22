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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}

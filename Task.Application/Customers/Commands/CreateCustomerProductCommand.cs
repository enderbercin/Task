using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Persistance.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class CreateCustomerProductCommandRequest : IRequest<bool>
    {
        public AddCustomerProductDto CustomerProduct { get; set; }
        public CreateCustomerProductCommandRequest(AddCustomerProductDto customerProduct)
        {
            CustomerProduct = customerProduct;
        }

    }
    public class CreateCustomerProductCommandHandler : IRequestHandler<CreateCustomerProductCommandRequest, bool>
    {
        private readonly IUnitOfWork _unit;

        public CreateCustomerProductCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<bool> Handle(CreateCustomerProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.CustomerProduct == null)
                return false;

            var repo = _unit.GetRepository<CustomerProduct>();
            CustomerProduct customerProduct = new CustomerProduct
            {
                CustomerId = request.CustomerProduct.CustomerId,
                ProductId = request.CustomerProduct.ProductId,
                UsedPerMounth = request.CustomerProduct.UsedPerMonth
            };
            await repo.AddAsync(customerProduct);
            await _unit.SaveChangesAsync();
            return true;
        }
    }

}

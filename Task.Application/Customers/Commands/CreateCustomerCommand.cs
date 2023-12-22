using Persistance.Abstracts;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommandRequest : IRequest<Unit>
    {
        public readonly AddCustomerDto Customer;

        public CreateCustomerCommandRequest(AddCustomerDto customer)
        {
            Customer = customer;
        }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unit;

        public CreateCustomerCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Unit> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

            if (request.Customer != null)
            {
                Customer customerEntity = new Customer
                {
                    Name = request.Customer.Name,
                    Surname = request.Customer.Surname,
                    Type = request.Customer.Type,
                    Voiting = request.Customer.Voiting
                };
                await _unit.GetRepository<Customer>().AddAsync(customerEntity);
                await _unit.SaveChangesAsync();
                return Unit.Value;
            }
            return Unit.Value;
        
        }
    }
}

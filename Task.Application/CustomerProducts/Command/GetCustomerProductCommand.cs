using Domain.DTOs;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Persistance.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerProducts.Command
{
    public class GetCustomerProductCommandRequest : IRequest<GetCustomerProductDto>
    {
        public GetCustomerProductCommandRequest()
        {
        }
    }
    public class GetCustomerProductCommandHandler : IRequestHandler<GetCustomerProductCommandRequest, GetCustomerProductDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMediator _mediator;

        public GetCustomerProductCommandHandler(IUnitOfWork unit, IMediator mediator)
        {
            _unit = unit;
            _mediator = mediator;
        }

        public async Task<GetCustomerProductDto> Handle(GetCustomerProductCommandRequest request, CancellationToken cancellationToken)
        {
            List<GetCustomerProductDto> response = new List<GetCustomerProductDto>();
            var customers = await _unit.GetRepository<Customer>().GetAllAsync();
            var products = await _unit.GetRepository<Product>().GetAllAsync();
            var customerProductDto = new GetCustomerProductDto
            {
                CustomerList = customers.Select(customer => new CustomerRequestModel
                {
                    CustomerId = customer.Id,
                    CustomerName = $"{customer.Name} {customer.Surname}"
                }).ToList(),

                ProductList = products.Select(product => new ProductRequestModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name
                }).ToList()
            };

            return customerProductDto;
        }
    }
}

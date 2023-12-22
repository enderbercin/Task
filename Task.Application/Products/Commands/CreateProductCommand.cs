using Persistance.Abstracts;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class CreateProductCommandRequest : IRequest<Unit>
    {
        public readonly AddProductDto Product;

        public CreateProductCommandRequest(AddProductDto product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unit;

        public CreateProductCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            if (request.Product != null)
            {
                Product productEntity = new Product
                {
                    Name = request.Product.Name,
                    UnitPrice = request.Product.UnitPrice,
                    SubstituteProductId = string.IsNullOrEmpty(request.Product.SubstituteProductId) ? null : request.Product.SubstituteProductId,
                };
                await _unit.GetRepository<Product>().AddAsync(productEntity);
                await _unit.SaveChangesAsync();
                return Unit.Value;
            }
            return Unit.Value;

        }
    }
}
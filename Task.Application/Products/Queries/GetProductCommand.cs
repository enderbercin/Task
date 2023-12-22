using Persistance.Abstracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductCommandRequest : IRequest<List<Product>>
    {
        public string Id { get; set; }
        public string Search { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }

        public GetProductCommandRequest(string id, string search = "", int page = 1, int count = 10)
        {
            Id = id;
            Search = search;
            Page = page;
            Count = count;
        }
    }

    public class GetProductCommandHandler : IRequestHandler<GetProductCommandRequest, List<Product>>
    {
        private readonly IUnitOfWork _unit;

        public GetProductCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<List<Product>> Handle(GetProductCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _unit.GetRepository<Product>();

            if (!string.IsNullOrEmpty(request.Id))
            {
                var result = await repository.GetByIdAsync(request.Id);

                return new List<Product> { result };
            }

            IEnumerable<Product> data;

            if (!string.IsNullOrEmpty(request.Search))
            {
                data = await repository.FindAsync(p => p.Name.Contains(request.Search));
            }
            else
            {
                data = await repository.GetAllAsync();
            }

            return data.Skip((request.Page - 1) * request.Count).Take(request.Count).ToList();
        }
    }
}

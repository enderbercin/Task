using Persistance.Abstracts;
using Domain.Entities;
using MediatR;


namespace Application.Customers.Queries
{
    public class GetCustomerCommandRequest : IRequest<List<Customer>>
    {
        public string Id { get; set; }
        public string Search { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }

        public GetCustomerCommandRequest(string id, string search = "", int page = 1, int count = 10)
        {
            Id = id;
            Search = search;
            Page = page;
            Count = count;
        }
    }

    public class GetCustomerCommandHandler : IRequestHandler<GetCustomerCommandRequest, List<Customer>>
    {
        private readonly IUnitOfWork _unit;

        public GetCustomerCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<List<Customer>> Handle(GetCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _unit.GetRepository<Customer>();

            if (!string.IsNullOrEmpty(request.Id))
            {
                var result = await repository.GetByIdAsync(request.Id);

                return new List<Customer> { result };
            }

            IEnumerable<Customer> data;

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

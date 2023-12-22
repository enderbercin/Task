using Persistance.Abstracts;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries
{
    public class GetDashboardCommandRequest : IRequest<List<DashboardResponseDto>>
    {
    }
    public class GetDashboardCommandHandler : IRequestHandler<GetDashboardCommandRequest, List<DashboardResponseDto>>
    {
        private readonly IUnitOfWork _unit;

        public GetDashboardCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<List<DashboardResponseDto>> Handle(GetDashboardCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _unit.CustomerProductRepository.GetDashboard();

            return response;
        }
    }
}

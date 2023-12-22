using Application.Customers.Queries;
using Infrastructure.ExportToExcel;
using MediatR;
using Persistance.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerProducts.Queries
{
    public class GetExportExcelCommandRequest : IRequest<byte[]>
    {
        public GetExportExcelCommandRequest()
        {
        }
    }
    public class GetExportExcelCommandHandler : IRequestHandler<GetExportExcelCommandRequest, byte[]>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMediator _mediator;

        public GetExportExcelCommandHandler(IUnitOfWork unit, IMediator mediator)
        {
            _unit = unit;
            _mediator = mediator;
        }

        public async Task<byte[]> Handle(GetExportExcelCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(new GetDashboardCommandRequest());
            ExportToExcel exportToExcel = new ExportToExcel();
           var response =  exportToExcel.Export(data);
            return response;
        }
    }
}

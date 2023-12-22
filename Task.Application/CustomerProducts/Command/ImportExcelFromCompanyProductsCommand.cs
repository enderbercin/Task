using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistance.Abstracts;

namespace Application.CustomerProducts.Command
{
    public class ImportExcelFromCompanyProductsCommandRequest : IRequest<bool>
    {
        public IFormFile ExcelFile { get; set; }
        public ImportExcelFromCompanyProductsCommandRequest(IFormFile excelFile)
        {
            ExcelFile = excelFile;
        }
    }
    public class ImportExcelFromCompanyProductsCommandHandler : IRequestHandler<ImportExcelFromCompanyProductsCommandRequest, bool>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMediator _mediator;

        public ImportExcelFromCompanyProductsCommandHandler(IUnitOfWork unit, IMediator mediator)
        {
            _unit = unit;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ImportExcelFromCompanyProductsCommandRequest request, CancellationToken cancellationToken)
        {
            var repo = _unit.GetRepository<CustomerProduct>();
            var customerProducts = await repo.GetAllAsync();

            using (var stream = request.ExcelFile.OpenReadStream())
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(1);

                // Verileri okuma
                var rowCount = worksheet.RowsUsed().Count();
                for (int i = 2; i <= rowCount; i++)
                {
                    var customerId = worksheet.Cell(i, 1).Value.ToString();
                    var customerName = worksheet.Cell(i, 2).Value.ToString();
                    var productId = worksheet.Cell(i, 3).Value.ToString();
                    var productName = worksheet.Cell(i, 4).Value.ToString();
                    var mounthlyUsage = worksheet.Cell(i, 5).Value.ToString();
                    var unitPrice = worksheet.Cell(i, 6).Value.ToString();
                    var unitPricePerMounth = worksheet.Cell(i, 7).Value.ToString();
                    var customerProduct = customerProducts.Where(x => x.CustomerId == customerId && x.ProductId == productId).FirstOrDefault();

                    if (customerProduct != null)
                    {
                        customerProduct.UsedPerMounth += decimal.Parse(mounthlyUsage);
                        await repo.UpdateAsync(customerProduct);
                    }
                    else
                    {
                        CustomerProduct cp = new CustomerProduct
                        {
                            CustomerId = customerId,
                            ProductId = productId,
                            UsedPerMounth = decimal.Parse(mounthlyUsage)
                        };
                        repo.AddAsync(cp);
                    }


                }
            }
            if (await _unit.SaveChangesAsync() > 0)
                return true;
            return false;
        }
    }
}

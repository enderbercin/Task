using Application.CustomerProducts.Command;
using Application.CustomerProducts.Queries;
using ClosedXML.Excel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator Mediatr)
        {
            _mediator = Mediatr;
        }


        [HttpGet("ExportToExcel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var response = await _mediator.Send(new GetExportExcelCommandRequest());

            return File(response, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }

        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel([FromForm]IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya seçilmedi veya boş.");

            var response = await _mediator.Send(new ImportExcelFromCompanyProductsCommandRequest(file));
            return Ok(response);
        }

    }
}

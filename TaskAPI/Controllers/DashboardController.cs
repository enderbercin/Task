using Application.Customers.Queries;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator Mediatr)
        {
            _mediator = Mediatr;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DashboardResponseDto>))]

        public async Task<IActionResult> GetDashboard()
        {
            var response = await _mediator.Send(new GetDashboardCommandRequest());
            return Ok(response);
        }
    }
}

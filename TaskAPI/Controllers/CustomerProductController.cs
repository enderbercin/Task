using Application.CustomerProducts.Command;
using Application.Customers.Commands;
using Application.Products.Commands;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerProductController(IMediator Mediatr)
        {
            _mediator = Mediatr;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AddCustomerProductDto model)
        {
            var response =await _mediator.Send(new CreateCustomerProductCommandRequest(model));
            return Ok(response);
        }

        [HttpGet("GetCustomerProducts")]
        public async Task<IActionResult> GetCustomerProducts()
        {
            var response = await _mediator.Send(new GetCustomerProductCommandRequest());
            return Ok(response);
        }
    }
}

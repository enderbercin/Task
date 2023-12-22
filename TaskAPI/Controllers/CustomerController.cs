using Application.Customers.Commands;
using Application.Customers.Queries;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator Mediatr)
        {
            _mediator = Mediatr;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id boş olamaz.");
            var response =await _mediator.Send(new GetCustomerCommandRequest(id));
            return Ok(response);
        }
        [HttpGet("GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetCustomers()
        {
            string id = "";
            var response = await _mediator.Send(new GetCustomerCommandRequest(id));
            return Ok(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<IActionResult> Create([FromBody]AddCustomerDto model)
        {
            var response = await _mediator.Send(new CreateCustomerCommandRequest(model));
            return Ok(response);
        }
    }
}

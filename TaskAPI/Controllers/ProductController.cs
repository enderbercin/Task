using Application.Customers.Commands;
using Application.Customers.Queries;
using Application.Products.Commands;
using Application.Products.Queries;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator Mediatr)
        {
            _mediator = Mediatr;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id boş olamaz.");
            var response = await _mediator.Send(new GetProductCommandRequest(id));
            return Ok(response);
        }
        [HttpGet("GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> GetProducts()
        {
            string id = "";
            var response = await _mediator.Send(new GetProductCommandRequest(id));
            return Ok(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<IActionResult> Create([FromBody] AddProductDto model)
        {
            var response = await _mediator.Send(new CreateProductCommandRequest(model));
            return Ok(response);
        }

    }
}

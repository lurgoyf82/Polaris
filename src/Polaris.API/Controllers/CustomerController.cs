using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polaris.Application.Customers.Commands.CreateCustomer;
using Polaris.Application.Customers.Queries.GetCustomer;

namespace Polaris.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { customerId = id }, id);
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult<CustomerDto>> Get(Guid customerId)
        {
            var result = await _mediator.Send(new GetCustomerQuery(customerId));
            return result is not null ? Ok(result) : NotFound();
        }
    }
}

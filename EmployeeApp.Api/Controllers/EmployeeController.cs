using System;
using System.Threading.Tasks;
using EmployeeApp.Domain.Messages.Commands;
using EmployeeApp.Domain.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetEmployee() {Id = id});
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateEmployee request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(CreateEmployee request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployee() {Id = id});
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

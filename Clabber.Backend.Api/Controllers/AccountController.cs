using Clabber.Backend.Api.Extensions;
using Clabber.Backend.Application.Commands.Account;
using Clabber.Backend.Application.Queries.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clabber.Backend.Api.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAccountCommand command)
        {
            var addResult = await this.mediator.Send(command);
            return this.ToActionResult(addResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] GetAccountPageQuery query)
        {
            var getAllResult = await this.mediator.Send(query);
            return this.ToActionResult(getAllResult);
        }
        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetById([FromRoute] GetAccountByIdQuery query)
        {
            var getByIdResult = await this.mediator.Send(query);
            return this.ToActionResult(getByIdResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComplete([FromBody] UpdateCompleteAccountCommand command)
        {
            var updateResult = await this.mediator.Send(command);
            return this.ToActionResult(updateResult);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePartial([FromBody] UpdatePartialAccountCommand command)
        {
            var updateResult = await this.mediator.Send(command);
            return this.ToActionResult(updateResult);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var command = new DeleteAccountCommand() { Id = id };
            var deleteResult = await this.mediator.Send(command);
            return this.ToActionResult(deleteResult);
        }
    }
}

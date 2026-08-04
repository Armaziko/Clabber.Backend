using Clabber.Backend.Api.Extensions;
using Clabber.Backend.Application.Commands.Account;
using Clabber.Backend.Application.DTOs.RequestDTOs.Account;
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
        public async Task<IActionResult> Add([FromBody] CreateAccountDto dto)
        {
            var addResult = await this.mediator.Send(new CreateAccountCommand(dto));
            return this.ToActionResult(addResult);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAccountPage([FromQuery] GetAccountPageQuery query)
        {
            var getAllResult = await this.mediator.Send(query);
            return this.ToActionResult(getAllResult);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetAccountByIdQuery query = new GetAccountByIdQuery() { Id = id };
            var getByIdResult = await this.mediator.Send(query);
            return this.ToActionResult(getByIdResult);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateComplete([FromRoute] Guid id, [FromBody] CompleteUpdateAccountDto dto)
        {
            if (id != dto.Id)
            {
                return this.BadRequest();
            }

            var updateResult = await this.mediator.Send(new UpdateCompleteAccountCommand(dto));
            return this.ToActionResult(updateResult);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdatePartial([FromRoute] Guid id, [FromBody] PartialUpdateAccountDto dto)
        {
            if (id != dto.Id)
            {
                return this.BadRequest();
            }

            var updateResult = await this.mediator.Send(new UpdatePartialAccountCommand(dto));
            return this.ToActionResult(updateResult);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var command = new DeleteAccountCommand(id);
            var deleteResult = await this.mediator.Send(command);
            return this.ToActionResult(deleteResult);
        }
    }
}

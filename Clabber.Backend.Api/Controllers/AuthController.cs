using Clabber.Backend.Api.Extensions;
using Clabber.Backend.Application.CQRS.Commands.Auth;
using Clabber.Backend.Application.DTOs.RequestDTOs.Auth;
using Clabber.Backend.Infrastructure.Config;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Clabber.Backend.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly AuthBearerTokenConfig tokenConfig;
        public AuthController(IMediator mediator, IOptions<AuthBearerTokenConfig> tokenOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.tokenConfig = tokenOptions.Value ?? throw new ArgumentNullException(nameof(tokenOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateDto dto)
        {
            var result = await this.mediator.Send(new AuthenticateCommand(dto));
            if (result.IsSuccess && result.Value != null)
            {
                this.HttpContext.Response.Cookies.Append(this.tokenConfig.AuthCookieName, result.Value);
                result.Value = null; 
            }
            return this.ToActionResult(result);
        }
    }
}

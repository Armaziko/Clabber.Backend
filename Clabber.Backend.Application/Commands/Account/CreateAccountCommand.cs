using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class CreateAccountCommand : IRequest<Result>
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

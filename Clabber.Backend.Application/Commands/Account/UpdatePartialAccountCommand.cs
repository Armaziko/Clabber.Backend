using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class UpdatePartialAccountCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? Mail { get; set; }
    }
}

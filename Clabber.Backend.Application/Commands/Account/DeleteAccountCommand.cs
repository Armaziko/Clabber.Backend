using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public record DeleteAccountCommand(Guid Id) : IRequest<Result>;
}

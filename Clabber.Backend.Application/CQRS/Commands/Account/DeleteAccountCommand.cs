using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.CQRS.Commands.Account
{
    public record DeleteAccountCommand(Guid Id) : IRequest<Result>;
}

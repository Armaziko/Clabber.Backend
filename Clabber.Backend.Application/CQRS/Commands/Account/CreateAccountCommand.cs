using Clabber.Backend.Application.DTOs.RequestDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.CQRS.Commands.Account
{
    public record CreateAccountCommand(CreateAccountDto Model) : IRequest<Result>;
}

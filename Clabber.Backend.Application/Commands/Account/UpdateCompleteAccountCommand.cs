using Clabber.Backend.Application.DTOs.RequestDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public record UpdateCompleteAccountCommand(CompleteUpdateAccountDto Model) : IRequest<Result>;
}

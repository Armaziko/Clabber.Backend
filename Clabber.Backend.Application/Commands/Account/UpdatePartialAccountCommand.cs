using Clabber.Backend.Application.DTOs.RequestDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public record UpdatePartialAccountCommand(PartialUpdateAccountDto Model) : IRequest<Result>;
}

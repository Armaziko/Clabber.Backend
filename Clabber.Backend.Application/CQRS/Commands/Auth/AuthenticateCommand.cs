using Clabber.Backend.Application.DTOs.RequestDTOs.Auth;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.CQRS.Commands.Auth
{
    public record AuthenticateCommand(AuthenticateDto AuthDto) : IRequest<Result<string>>;
}

using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class DeleteAccountCommand : IRequest<Result>
    {
        public Guid Id { get; set;  }
    }
}

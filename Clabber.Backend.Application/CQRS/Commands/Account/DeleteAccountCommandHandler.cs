using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.CQRS.Commands.Account
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
    {
        public Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
    {
        public Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

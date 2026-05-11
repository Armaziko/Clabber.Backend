using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class UpdateCompleteAccountHandler : IRequestHandler<UpdateCompleteAccountCommand, Result>
    {
        public Task<Result> Handle(UpdateCompleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

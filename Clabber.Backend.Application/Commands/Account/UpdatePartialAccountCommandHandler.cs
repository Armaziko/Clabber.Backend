using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Commands.Account
{
    public class UpdatePartialAccountCommandHandler : IRequestHandler<UpdatePartialAccountCommand, Result>
    {
        public Task<Result> Handle(UpdatePartialAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

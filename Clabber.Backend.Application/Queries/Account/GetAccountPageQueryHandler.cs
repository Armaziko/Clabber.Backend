using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Queries.Account
{
    public class GetAccountPageQueryHandler : IRequestHandler<GetAccountPageQuery, Result<IReadOnlyList<AccountDto>>>
    {
        public Task<Result<IReadOnlyList<AccountDto>>> Handle(GetAccountPageQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

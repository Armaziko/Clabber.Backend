using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Queries.Account
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Result<AccountDto>>
    {
        public Task<Result<AccountDto>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Queries.Account
{
    public class GetAccountByIdQuery : IRequest<Result<AccountDto>>
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}

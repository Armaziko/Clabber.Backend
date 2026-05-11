using Clabber.Backend.Application.DTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Queries.Account
{
    public class GetAccountByIdQuery : IRequest<Result<AccountDto>>
    {
        public string Id { get; set; } = default!;
    }
}

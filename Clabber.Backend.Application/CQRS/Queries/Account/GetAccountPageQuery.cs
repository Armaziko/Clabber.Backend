using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.CQRS.Queries.Account
{
    public class GetAccountPageQuery : IRequest<Result<IReadOnlyList<AccountDto>>>
    {
        public int Page { get; set; } = 0;
        public int ElementsPerPage { get; set; } = 8;
        public bool? OnlyCreators { get; set; }
        public bool? OnlySponsors { get; set; }
        public bool? OnlyVerified { get; set; }
    }
}

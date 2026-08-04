using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;

namespace Clabber.Backend.Application.Queries.Account
{
    public class GetAccountPageQuery : IRequest<Result<IReadOnlyList<AccountDto>>>
    {
        public int Page { get; set; }
        public int ElementsPerPage { get; set; }
        public bool? OnlyCreators { get; set; }
        public bool? OnlySponsors { get; set; }
        public bool? OnlyVerified { get; set; }
    }
}

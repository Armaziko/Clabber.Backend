using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using DomainAccount = Clabber.Backend.Domain.Entities.Profile.Account;
using MediatR;
using Clabber.Backend.Application.Specification;

namespace Clabber.Backend.Application.CQRS.Queries.Account
{
    public class GetAccountPageQueryHandler : IRequestHandler<GetAccountPageQuery, Result<IReadOnlyList<AccountDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAccountPageQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<IReadOnlyList<AccountDto>>> Handle(GetAccountPageQuery request, CancellationToken cancellationToken)
        {
            var repo = this.unitOfWork.Repository<DomainAccount>();

            var specification = new Specification<DomainAccount>(x => !(request.OnlyVerified ?? false) || (x.Verification != null && x.Verification.Status == Domain.Enums.VerificationStatus.Verified));
            specification.AddInclude(x => x.Verification!);
            specification.AsNoTrackingQuery();
            specification.AddOrderBy(x => x.DisplayName);
            var users = await repo.GetPageAsync(request.Page, request.ElementsPerPage, specification);

            var usersDto = users?.Select(x => new AccountDto() 
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                Email = !string.IsNullOrWhiteSpace(x.Email) ? x.Email : "anonymous@nomail.com"
            }).ToList();

            return Result<IReadOnlyList<AccountDto>>.Success(usersDto ?? []);
        }
    }
}
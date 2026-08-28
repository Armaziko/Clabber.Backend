using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.DTOs.ResponseDTOs.Account;
using Clabber.Backend.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using DomainAccount = Clabber.Backend.Domain.Entities.Profile.Account;

namespace Clabber.Backend.Application.CQRS.Queries.Account
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Result<AccountDto>>
    {
        private readonly UserManager<DomainAccount> userManager;
        public GetAccountByIdQueryHandler(UserManager<DomainAccount> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<Result<AccountDto>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByIdAsync(request.Id.ToString());

            if (user is null)
            {
                return Result<AccountDto>.NotFound();
            }

            return Result<AccountDto>.Success(new AccountDto() 
                { 
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Email = !string.IsNullOrWhiteSpace(user.Email) ? user.Email : "anonymous@nomail.com" 
                });
        }
    }
}

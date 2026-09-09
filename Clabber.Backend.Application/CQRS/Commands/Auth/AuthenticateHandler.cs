using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.Models.Auth;
using Clabber.Backend.Application.Results;
using Clabber.Backend.Domain.Entities.Profile;
using MediatR;
using Microsoft.AspNetCore.Identity;
using DomainAccount = Clabber.Backend.Domain.Entities.Profile.Account;

namespace Clabber.Backend.Application.CQRS.Commands.Auth
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, Result<string>>
    {
        private readonly UserManager<DomainAccount> userManager;
        private readonly IBearerTokenGenerator tokenGenerator;
        public AuthenticateHandler(UserManager<DomainAccount> userManager, IBearerTokenGenerator tokenGenerator)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
        }
        public async Task<Result<string>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            //Validate DTO
            bool isEmail = request.AuthDto.UserNameOrEmail.Contains('@');
            DomainAccount? user;
            if (isEmail)
            {
                user = await this.userManager.FindByEmailAsync(request.AuthDto.UserNameOrEmail);
            }
            else
            {
                user = await this.userManager.FindByNameAsync(request.AuthDto.UserNameOrEmail);
            }

            if (user is null)
            {
                return Result<string>.NotFound();
            }

            if (!await this.userManager.CheckPasswordAsync(user, request.AuthDto.Password))
            {
                return Result<string>.Unauthorized();
            }

            var role =  (await this.userManager.GetRolesAsync(user)).FirstOrDefault();
            
            var token = this.tokenGenerator.GetBearerToken(new UserClaims() { Id = user.Id, Role = role ?? "" });
            return Result<string>.Success(token);
        }
    }
}

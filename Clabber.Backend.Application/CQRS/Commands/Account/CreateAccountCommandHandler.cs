using Clabber.Backend.Application.Exceptions;
using Clabber.Backend.Application.Results;
using DomainAccount = Clabber.Backend.Domain.Entities.Profile.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Clabber.Backend.Application.CQRS.Commands.Account
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result>
    {
        private readonly ILogger<CreateAccountCommandHandler> logger;
        private readonly UserManager<DomainAccount> userManager;

        public CreateAccountCommandHandler(
            ILogger<CreateAccountCommandHandler> logger,
            UserManager<DomainAccount> userManager)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newAccount = DomainAccount.CreateNew(request.Model.DisplayName, request.Model.UserName, request.Model.Mail);
                await userManager.CreateAsync(newAccount, request.Model.Password);

                var result = await userManager.CreateAsync(newAccount, request.Model.Password);

                if (!result.Succeeded)
                {
                    return Result.Failed();
                }
                
                    return Result.Success();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Something went wrong.");
                return Result.Failed();
            }
        }
    }
}

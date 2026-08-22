using Clabber.Backend.Application.Exceptions;
using Clabber.Backend.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Clabber.Backend.Application.Commands.Account
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result>
    {
        private readonly ILogger<CreateAccountCommandHandler> logger;
        private readonly UserManager<Domain.Entities.Profile.Account> userManager;

        public CreateAccountCommandHandler(
            ILogger<CreateAccountCommandHandler> logger,
            UserManager<Domain.Entities.Profile.Account> userManager)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newAccount = Domain.Entities.Profile.Account.CreateNew(request.Model.DisplayName, request.Model.Mail);
                await userManager.CreateAsync(newAccount, request.Model.Password);
                return Result.Success();
            }
            catch (IdentityException ie)
            {
                this.logger.LogError(ie, "An Identity error has occured.");
                return Result.Failed();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Something went wrong.");
                return Result.Failed();
            }
        }
    }
}

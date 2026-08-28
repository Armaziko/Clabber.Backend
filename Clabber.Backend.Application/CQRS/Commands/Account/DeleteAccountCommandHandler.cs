using Clabber.Backend.Application.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DomainAccount = Clabber.Backend.Domain.Entities.Profile.Account;

namespace Clabber.Backend.Application.CQRS.Commands.Account
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
    {
        private readonly UserManager<DomainAccount> userManager;
        private readonly ILogger<DeleteAccountCommandHandler> logger;
        public DeleteAccountCommandHandler(UserManager<DomainAccount> userManager, ILogger<DeleteAccountCommandHandler> logger)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) 
            {
                return Result.NotFound();
            }

            try
            {
                var attemptDelete = await this.userManager.DeleteAsync(user);
                if (!attemptDelete.Succeeded)
                {
                    return Result.Failed();
                }

                return Result.Success();
            }
            catch(DbUpdateException dbException)
            {
                this.logger.LogError(dbException, "An exception has occured while attempting to delete an user: {Message}", dbException.Message);
                return Result.Failed();
            } 
        }
    }
}

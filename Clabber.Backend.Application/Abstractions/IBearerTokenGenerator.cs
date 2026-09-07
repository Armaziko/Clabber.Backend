using Clabber.Backend.Application.Models.Auth;

namespace Clabber.Backend.Application.Abstractions
{
    public interface IBearerTokenGenerator
    {
        public string GetBearerToken(UserClaims userClaims);
    }
}

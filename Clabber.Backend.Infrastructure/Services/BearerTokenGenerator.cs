using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.Models.Auth;
using Clabber.Backend.Infrastructure.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clabber.Backend.Infrastructure.Services
{
    public class BearerTokenGenerator : IBearerTokenGenerator
    {
        private readonly AuthBearerTokenConfig tokenConfig;
        public BearerTokenGenerator(IOptions<AuthBearerTokenConfig> authOptions)
        {
            tokenConfig = authOptions.Value;
        }
        public string GetBearerToken(UserClaims userClaims)
        {
            var claims = new[]{
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, userClaims.Id.ToString()),
                new Claim(ClaimTypes.Role, userClaims.Role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.IssuerSigningKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Sha256);

            var jwt = new JwtSecurityToken(
                issuer: tokenConfig.ValidIssuer, 
                audience: tokenConfig.ValidAudience, 
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenConfig.TokenLifetimeInMinutes),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

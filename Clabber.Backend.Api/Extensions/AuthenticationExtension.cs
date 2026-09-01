using Clabber.Backend.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clabber.Backend.Api.Extensions
{
    public static class AuthenticationExtension
    {
        public static void SetUpAuthentication(this IHostApplicationBuilder builder)
        {
            var configs = builder.Configuration.GetSection(AuthOptions.NameTitle).Get<AuthOptions>();
            if (configs == null)
            {
                throw new InvalidOperationException($"The {AuthOptions.NameTitle} in appsettings couldn't be extracted into 'configs' variable");
            }

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {

                options.IncludeErrorDetails = false;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = configs.ValidIssuer,
                    ValidAudience = configs.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configs.IssuerSigningKey))
                };

                options.Events.OnMessageReceived = context =>
                {
                    if (context != null) 
                    {
                        context.Token = context.Request.Cookies[configs.AuthCookieName];
                    }

                    return Task.CompletedTask;
                };
            });
        }
    } 
}

using Avhrm.Identity.Server.Services;
using Avhrm.Identity.Server.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Claims;

namespace Avhrm.Identity.Server.Extensions;

public static class AuthorizationExtension
{
    public static void AddAvhrmAuthorize(this IServiceCollection services
        , IConfiguration configuration)
    {
        var configSec = configuration.GetSection("Identity");

        services.AddAuthorization();
        
        services.AddAuthentication();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;

            options.SaveToken = true;

            options.TokenValidationParameters = new()
            {
                ClockSkew = TimeSpan.Zero,// not before & expires tolerance
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = CryptographyTools.GetSymmetricKey(configSec["Signing"]),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = configSec["Audience"],
                ValidateIssuer = true,
                ValidIssuer = configSec["Issuer"],
                TokenDecryptionKey = CryptographyTools.GetSymmetricKey("84311GFT66934ECC")
            };

            options.Events = new()
            {
                OnChallenge = async context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                    //context.Response.ContentType = "application/json";

                    //await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse()
                    //{
                    //    Successful = false,
                    //    Messages = new string[]
                    //    {
                    //        TextResources.APP_StringKeys_Error_TokenInvalid
                    //    }
                    //}));
                },

                OnAuthenticationFailed = async context =>
                {
                    context.Fail("fail");
                },

                OnTokenValidated = async context =>
                {
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;

                    if (claimsIdentity.Claims?.Count() == 0)
                    {
                        context.Fail("This token has no claims.");
                    }
                },

                OnMessageReceived = context =>
                {
                    context.HttpContext.RequestServices
                           .GetRequiredService<ILogger<JwtBearerEvents>>().LogInformation("Jwt is validating ...");

                    return Task.CompletedTask;
                }
            };
        });
    }
}

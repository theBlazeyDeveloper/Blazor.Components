using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Components.Authentication.Services
{
    public sealed class DefaultAuthenticationStateProvider : AuthenticationStateProvider
    {
        public DefaultAuthenticationStateProvider() : base()
        { }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {            
            var identity = new ClaimsIdentity(GenerateDefaultUserClaims());
            var principal = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(principal));
        }

        static Claim[] GenerateDefaultUserClaims()
        {
            return new[]
            {
                new Claim(ClaimTypes.Anonymous, "Anonymous User"),
                new Claim(ClaimTypes.Authentication, "false")
            };
        }
    }
}

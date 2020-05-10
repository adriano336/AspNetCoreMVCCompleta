using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevIO.App.Extensions
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
            : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new[] { new Claim(claimName, claimValue) };
        }
    }
}


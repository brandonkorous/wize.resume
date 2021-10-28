using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace wize.resume.odata.Config
{
    public class HasPermissionsHandler : AuthorizationHandler<HasPermissionsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionsRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "permissions" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var scopes = context.User.FindAll(c => c.Type == "permissions" && c.Issuer == requirement.Issuer);

            if (scopes.Any(p => p.Value == requirement.Permissions))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

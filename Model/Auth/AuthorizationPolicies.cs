using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Model.Auth;

public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options => { });
    }
}
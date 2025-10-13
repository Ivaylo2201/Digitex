using System.Security.Claims;

namespace Backend.Infrastructure.Extensions;

public static class ClaimPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal principal)
    {
        var id = principal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return int.Parse(id);
    }
}
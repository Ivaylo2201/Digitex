using System.Security.Claims;
using Backend.Infrastructure.Common;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Extensions;

public static class AuthorizedExtensions
{
    public static TRequest SetUserId<TRequest>(this TRequest request, HttpContext context) where TRequest : IAuthorized
    {
        request.UserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        return request;
    }
}
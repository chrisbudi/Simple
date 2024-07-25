
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SimpleCliniq.Common.Domain;
using SimpleCliniq.Common.Infrastructure.Authentication;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Users.Application.Users.GetUser;
using System.Security.Claims;

namespace SimpleCliniq.Module.Users.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/profile", async (ClaimsPrincipal claims, ISender sender) =>
        {
            Result<UserResponse> result = await sender.Send(new GetUserQuery(claims.GetUserId()));

            return result.(Results.Ok, ApiResults.Problem);
        })
        .RequireAuthorization(Permissions.GetUser)
        .WithTags(Tags.Users);
    }

    public void MapEndPoint(IEndpointRouteBuilder builder)
    
        throw new NotImplementedException();
}
}

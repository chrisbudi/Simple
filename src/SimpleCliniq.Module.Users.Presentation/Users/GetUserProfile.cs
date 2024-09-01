using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Infrastructure.Authentication;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
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

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .RequireAuthorization()
        //.RequireAuthorization(Permissions.GetUser)
        .WithTags(Tags.Users);


        app.MapGet("users/test", () =>
        {
            return Results.Ok("Test");
        })
            .RequireAuthorization()
            .WithTags(Tags.Users);

    }

}

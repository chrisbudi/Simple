using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Users.Application.Users.RegisterUser;

namespace SimpleCliniq.Module.Users.Presentation.Users;

internal sealed class RegisterUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new RegisterUserCommand(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Users);

        //app.MapPost("users/login", async (Request request, ISender sender) =>
        //{
        //    Result<Guid> result = await sender.Send(new LoginUserCommand(
        //        request.Email,
        //        request.Password));

        //    return result.Match(Results.Ok, ApiResults.Problem);
        //})
        //.AllowAnonymous()
        //.WithTags(Tags.Users);

    }

    internal sealed class Request
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.SMF.DeleteSmf;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteSmf : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.SMF + "/{Id}", async (ISender sender, [AsParameters]DeleteSmfCommand query) =>
        {
            Result<DeleteSmfResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteSmf")
        .WithTags(Tags.SMF)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

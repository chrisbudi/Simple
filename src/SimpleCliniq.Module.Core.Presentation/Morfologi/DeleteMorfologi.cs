using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Morfologi.DeleteMorfologi;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteMorfologi : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Morfologi, async (ISender sender, [AsParameters]DeleteMorfologiCommand query) =>
        {
            Result<DeleteMorfologiResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteMorfologi")
        .WithTags(Tags.Morfologi)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

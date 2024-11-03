using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Rekanan.DeleteRekanan;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Rekanan + "/{Id}", async (ISender sender, [AsParameters]DeleteRekananCommand query) =>
        {
            Result<DeleteRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteRekanan")
        .WithTags(Tags.Rekanan)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

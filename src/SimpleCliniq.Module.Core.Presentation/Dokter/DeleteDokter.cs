using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Dokter.DeleteDokter;

namespace SimpleCliniq.Module.Core.Presentation.Dokter;

public class DeleteDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Dokter, async (ISender sender, [AsParameters]DeleteDokterCommand query) =>
        {
            Result<DeleteDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteDokter")
        .WithTags(Tags.Dokter)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

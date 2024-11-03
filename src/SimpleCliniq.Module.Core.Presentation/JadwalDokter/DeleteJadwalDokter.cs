using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.JadwalDokter.DeleteJadwalDokter;

namespace SimpleCliniq.Module.Core.Presentation.JadwalDokter;

public class DeleteJadwalDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.JadwalDokter+ "/{Id}", async (ISender sender, [AsParameters]DeleteJadwalDokterCommand query) =>
        {
            Result<DeleteJadwalDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteJadwalDokter")
        .WithTags(Tags.JadwalDokter)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

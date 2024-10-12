using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.JadwalDokter.UpdateJadwalDokter;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.JadwalDokter;

public class UpdateJadwalDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.JadwalDokter, async (ISender sender, [AsParameters]UpdateJadwalDokterCommand query) =>
        {
            Result<UpdateJadwalDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateJadwalDokter")
        .WithTags(Tags.JadwalDokter)
        .Produces<MJadwalDokter>(StatusCodes.Status200OK);
    }
}

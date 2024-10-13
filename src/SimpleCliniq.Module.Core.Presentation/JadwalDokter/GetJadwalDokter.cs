using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.JadwalDokter;
using SimpleCliniq.Module.Core.Application.JadwalDokter.GetJadwalDokter;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.JadwalDokter;

public class GetJadwalDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.JadwalDokter + "/{id}", async (ISender sender, [AsParameters]GetJadwalDokterQuery query) =>
        {
            Result<GetJadwalDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetJadwalDokterById")
        .WithTags(Tags.JadwalDokter)
        .Produces<MJadwalDokter>(StatusCodes.Status200OK);
    }
}

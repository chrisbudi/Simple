using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.JadwalDokter.CreateJadwalDokter;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.JadwalDokter;

public class CreateJadwalDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.JadwalDokter, async (ISender sender, [AsParameters]CreateJadwalDokterCommand query) =>
        {
            Result<CreateJadwalDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateJadwalDokter")
        .WithTags(Tags.JadwalDokter)
        .Produces<MJadwalDokter>(StatusCodes.Status200OK);
    }
}

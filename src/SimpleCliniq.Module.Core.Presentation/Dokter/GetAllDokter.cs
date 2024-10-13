using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Dokter.GetDokter;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Dokter;

public class GetAllDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Dokter, async (ISender sender, [AsParameters]GetAllDokterQuery query) =>
        {
            Result<GetAllDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllDokter")
        .WithTags(Tags.Dokter)
        .Produces<MDokter[]>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Dokter;
using SimpleCliniq.Module.Core.Application.Dokter.GetDokter;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Dokter;

public class GetDokter : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Dokter + "/{id}", async (ISender sender, [AsParameters]GetDokterQuery query) =>
        {
            Result<GetDokterResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetDokterById")
        .WithTags(Tags.Dokter)
        .Produces<MDokter>(StatusCodes.Status200OK);
    }
}

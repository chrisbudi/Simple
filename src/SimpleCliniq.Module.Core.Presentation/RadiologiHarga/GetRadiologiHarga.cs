using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiHarga.GetRadiologiHarga;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiHarga;

public class GetRadiologiHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.RadiologiHarga + "/{id}", async (ISender sender, [AsParameters]GetRadiologiHargaQuery query) =>
        {
            Result<GetRadiologiHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetRadiologiHargaById")
        .WithTags(Tags.RadiologiHarga)
        .Produces<MRadiologiHarga>(StatusCodes.Status200OK);
    }
}

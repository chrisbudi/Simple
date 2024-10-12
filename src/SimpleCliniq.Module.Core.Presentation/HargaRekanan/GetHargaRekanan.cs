using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.HargaRekanan;
using SimpleCliniq.Module.Core.Application.HargaRekanan.GetHargaRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.HargaRekanan;

public class GetHargaRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.HargaRekanan + "/{id}", async (ISender sender, [AsParameters]GetHargaRekananQuery query) =>
        {
            Result<GetHargaRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetHargaRekananById")
        .WithTags(Tags.HargaRekanan)
        .Produces<MHargaRekanan>(StatusCodes.Status200OK);
    }
}

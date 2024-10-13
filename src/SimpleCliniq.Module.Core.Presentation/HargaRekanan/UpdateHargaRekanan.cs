using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.HargaRekanan.UpdateHargaRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.HargaRekanan;

public class UpdateHargaRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.HargaRekanan, async (ISender sender, [AsParameters]UpdateHargaRekananCommand query) =>
        {
            Result<UpdateHargaRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateHargaRekanan")
        .WithTags(Tags.HargaRekanan)
        .Produces<MHargaRekanan>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.HargaRekanan.CreateHargaRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.HargaRekanan;

public class CreateHargaRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.HargaRekanan, async (ISender sender, [AsParameters]CreateHargaRekananCommand query) =>
        {
            Result<CreateHargaRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateHargaRekanan")
        .WithTags(Tags.HargaRekanan)
        .Produces<MHargaRekanan>(StatusCodes.Status200OK);
    }
}

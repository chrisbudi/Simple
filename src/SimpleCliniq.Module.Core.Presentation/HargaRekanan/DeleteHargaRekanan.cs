using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.HargaRekanan.DeleteHargaRekanan;

namespace SimpleCliniq.Module.Core.Presentation.HargaRekanan;

public class DeleteHargaRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.HargaRekanan+ "/{Id}", async (ISender sender, [AsParameters]DeleteHargaRekananCommand query) =>
        {
            Result<DeleteHargaRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteHargaRekanan")
        .WithTags(Tags.HargaRekanan)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

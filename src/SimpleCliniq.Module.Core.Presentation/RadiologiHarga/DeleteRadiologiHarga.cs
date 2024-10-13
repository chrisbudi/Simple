using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiHarga.DeleteRadiologiHarga;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiHarga;

public class DeleteRadiologiHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.RadiologiHarga, async (ISender sender, [AsParameters]DeleteRadiologiHargaCommand query) =>
        {
            Result<DeleteRadiologiHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteRadiologiHarga")
        .WithTags(Tags.RadiologiHarga)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

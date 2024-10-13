using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiHarga.UpdateRadiologiHarga;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiHarga;

public class UpdateRadiologiHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.RadiologiHarga, async (ISender sender, [AsParameters]UpdateRadiologiHargaCommand query) =>
        {
            Result<UpdateRadiologiHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateRadiologiHarga")
        .WithTags(Tags.RadiologiHarga)
        .Produces<MRadiologiHarga>(StatusCodes.Status200OK);
    }
}

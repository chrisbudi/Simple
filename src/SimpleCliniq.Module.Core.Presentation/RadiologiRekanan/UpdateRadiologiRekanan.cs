using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiRekanan.UpdateRadiologiRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiRekanan;

public class UpdateRadiologiRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.RadiologiRekanan, async (ISender sender, [AsParameters]UpdateRadiologiRekananCommand query) =>
        {
            Result<UpdateRadiologiRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateRadiologiRekanan")
        .WithTags(Tags.RadiologiRekanan)
        .Produces<MRadiologiRekanan>(StatusCodes.Status200OK);
    }
}

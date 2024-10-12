using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiRekanan.GetRadiologiRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiRekanan;

public class GetRadiologiRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.RadiologiRekanan + "/{id}", async (ISender sender, [AsParameters]GetRadiologiRekananQuery query) =>
        {
            Result<GetRadiologiRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetRadiologiRekananById")
        .WithTags(Tags.RadiologiRekanan)
        .Produces<MRadiologiRekanan>(StatusCodes.Status200OK);
    }
}

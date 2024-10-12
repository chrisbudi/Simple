using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiRekanan.CreateRadiologiRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiRekanan;

public class CreateRadiologiRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.RadiologiRekanan, async (ISender sender, [AsParameters]CreateRadiologiRekananCommand query) =>
        {
            Result<CreateRadiologiRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateRadiologiRekanan")
        .WithTags(Tags.RadiologiRekanan)
        .Produces<MRadiologiRekanan>(StatusCodes.Status200OK);
    }
}

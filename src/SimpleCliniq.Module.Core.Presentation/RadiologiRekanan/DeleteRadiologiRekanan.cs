using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.RadiologiRekanan.DeleteRadiologiRekanan;

namespace SimpleCliniq.Module.Core.Presentation.RadiologiRekanan;

public class DeleteRadiologiRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.RadiologiRekanan, async (ISender sender, [AsParameters]DeleteRadiologiRekananCommand query) =>
        {
            Result<DeleteRadiologiRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteRadiologiRekanan")
        .WithTags(Tags.RadiologiRekanan)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

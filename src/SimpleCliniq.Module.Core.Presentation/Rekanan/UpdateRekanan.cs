using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Rekanan.UpdateRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class UpdateRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.Rekanan, async (ISender sender, [AsParameters]UpdateRekananCommand query) =>
        {
            Result<UpdateRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateRekanan")
        .WithTags(Tags.Rekanan)
        .Produces<MRekanan>(StatusCodes.Status200OK);
    }
}

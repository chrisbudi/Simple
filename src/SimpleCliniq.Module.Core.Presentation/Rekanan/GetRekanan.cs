using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Rekanan;

public class GetRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Rekanan + "/{id}", async (ISender sender, [AsParameters]GetRekananQuery query) =>
        {
            Result<GetRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetRekananById")
        .WithTags(Tags.Rekanan)
        .Produces<MRekanan>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Ruang.CreateRuang;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class CreateRuang : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.Ruang, async (ISender sender, [AsParameters]CreateRuangCommand query) =>
        {
            Result<CreateRuangResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateRuang")
        .WithTags(Tags.Ruang)
        .Produces<MRuang>(StatusCodes.Status200OK);
    }
}

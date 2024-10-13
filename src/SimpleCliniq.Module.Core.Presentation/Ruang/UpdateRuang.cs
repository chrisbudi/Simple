using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Ruang.UpdateRuang;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class UpdateRuang : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.Ruang, async (ISender sender, [AsParameters]UpdateRuangCommand query) =>
        {
            Result<UpdateRuangResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateRuang")
        .WithTags(Tags.Ruang)
        .Produces<MRuang>(StatusCodes.Status200OK);
    }
}

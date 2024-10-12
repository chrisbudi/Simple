using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Ruang.GetRuang;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Ruang;

public class GetAllRuang : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Ruang, async (ISender sender, [AsParameters]GetAllRuangQuery query) =>
        {
            Result<GetAllRuangResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllRuang")
        .WithTags(Tags.Ruang)
        .Produces<MRuang[]>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Ruang.DeleteRuang;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteRuang : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Ruang, async (ISender sender, [AsParameters]DeleteRuangCommand query) =>
        {
            Result<DeleteRuangResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteRuang")
        .WithTags(Tags.Ruang)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

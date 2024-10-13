using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DTD.DeleteDtd;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteDtd : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.DTD, async (ISender sender, [AsParameters]DeleteDtdCommand query) =>
        {
            Result<DeleteDtdResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteDtd")
        .WithTags(Tags.DTD)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DTD.UpdateDtd;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class UpdateDtd : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.DTD, async (ISender sender, [AsParameters]UpdateDtdCommand query) =>
        {
            Result<UpdateDtdResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateDtd")
        .WithTags(Tags.DTD)
        .Produces<MDtd>(StatusCodes.Status200OK);
    }
}

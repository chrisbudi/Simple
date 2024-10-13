using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DTD.GetDtd;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.DTD;

public class GetAllDtd : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.DTD, async (ISender sender, [AsParameters]GetAllDtdQuery query) =>
        {
            Result<GetAllDtdResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllDTD")
        .WithTags(Tags.DTD)
        .Produces<MDtd[]>(StatusCodes.Status200OK);
    }
}

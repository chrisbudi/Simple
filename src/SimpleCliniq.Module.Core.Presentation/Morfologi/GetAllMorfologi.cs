using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Morfologi;

public class GetAllMorfologi : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Morfologi, async (ISender sender, [AsParameters]GetAllMorfologiQuery query) =>
        {
            Result<GetAllMorfologiResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllMorfologi")
        .WithTags(Tags.Morfologi)
        .Produces<MMorfologi[]>(StatusCodes.Status200OK);
    }
}

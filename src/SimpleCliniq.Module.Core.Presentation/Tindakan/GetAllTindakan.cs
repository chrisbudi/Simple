using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Tindakan;

public class GetAllTindakan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Tindakan, async (ISender sender, [AsParameters]GetAllTindakanQuery query) =>
        {
            Result<GetAllTindakanResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllTindakan")
        .WithTags(Tags.Tindakan)
        .Produces<MTindakan[]>(StatusCodes.Status200OK);
    }
}

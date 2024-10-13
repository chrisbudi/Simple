using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Tindakan.UpdateTindakan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class UpdateTindakan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.Tindakan, async (ISender sender, [AsParameters]UpdateTindakanCommand query) =>
        {
            Result<UpdateTindakanResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateTindakan")
        .WithTags(Tags.Tindakan)
        .Produces<MTindakan>(StatusCodes.Status200OK);
    }
}

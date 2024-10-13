using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Tindakan.DeleteTindakan;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteTindakan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Tindakan, async (ISender sender, [AsParameters]DeleteTindakanCommand query) =>
        {
            Result<DeleteTindakanResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteTindakan")
        .WithTags(Tags.Tindakan)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

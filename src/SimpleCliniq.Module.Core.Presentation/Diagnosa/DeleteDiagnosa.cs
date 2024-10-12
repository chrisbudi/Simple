using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Diagnosa.DeleteDiagnosa;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DeleteDiagnosa : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Diagnosa, async (ISender sender, [AsParameters]DeleteDiagnosaCommand query) =>
        {
            Result<DeleteDiagnosaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteDiagnosa")
        .WithTags(Tags.Diagnosa)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

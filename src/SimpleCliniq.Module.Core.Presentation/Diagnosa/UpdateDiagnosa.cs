using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Diagnosa.UpdateDiagnosa;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class UpdateDiagnosa : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.Diagnosa, async (ISender sender, [AsParameters]UpdateDiagnosaCommand query) =>
        {
            Result<UpdateDiagnosaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateDiagnosa")
        .WithTags(Tags.Diagnosa)
        .Produces<MDiagnosa>(StatusCodes.Status200OK);
    }
}

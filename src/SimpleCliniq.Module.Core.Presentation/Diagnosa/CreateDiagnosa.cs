using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Diagnosa.CreateDiagnosa;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class CreateDiagnosa : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.Diagnosa, async (ISender sender, [AsParameters]CreateDiagnosaCommand query) =>
        {
            Result<CreateDiagnosaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateDiagnosa")
        .WithTags(Tags.Diagnosa)
        .Produces<MDiagnosa>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Diagnosa;
using SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class GetDiagnosa : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Diagnosa + "/{id}", async (ISender sender, [AsParameters]GetDiagnosaQuery query) =>
        {
            Result<GetDiagnosaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetDiagnosaById")
        .WithTags(Tags.Diagnosa)
        .Produces<MDiagnosa>(StatusCodes.Status200OK);
    }
}

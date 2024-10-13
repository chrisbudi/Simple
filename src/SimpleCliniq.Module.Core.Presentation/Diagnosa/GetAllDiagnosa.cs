using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class GetAllDiagnosa : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Diagnosa, async (ISender sender, [AsParameters]GetAllDiagnosaQuery query) =>
        {
            Result<GetAllDiagnosaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllDiagnosa")
        .WithTags(Tags.Diagnosa)
        .Produces<MDiagnosa[]>(StatusCodes.Status200OK);
    }
}

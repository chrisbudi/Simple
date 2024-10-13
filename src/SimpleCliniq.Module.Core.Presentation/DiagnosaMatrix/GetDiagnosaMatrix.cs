using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DiagnosaMatrix;
using SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.DiagnosaMatrix;

public class GetDiagnosaMatrix : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.DiagnosaMatrix + "/{id}", async (ISender sender, [AsParameters]GetDiagnosaMatrixQuery query) =>
        {
            Result<GetDiagnosaMatrixResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetDiagnosaMatrixById")
        .WithTags(Tags.DiagnosaMatrix)
        .Produces<MDiagnosaMatrix>(StatusCodes.Status200OK);
    }
}

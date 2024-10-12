using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DiagnosaMatrix.UpdateDiagnosaMatrix;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.DiagnosaMatrix;

public class UpdateDiagnosaMatrix : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.DiagnosaMatrix, async (ISender sender, [AsParameters]UpdateDiagnosaMatrixCommand query) =>
        {
            Result<UpdateDiagnosaMatrixResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateDiagnosaMatrix")
        .WithTags(Tags.DiagnosaMatrix)
        .Produces<MDiagnosaMatrix>(StatusCodes.Status200OK);
    }
}

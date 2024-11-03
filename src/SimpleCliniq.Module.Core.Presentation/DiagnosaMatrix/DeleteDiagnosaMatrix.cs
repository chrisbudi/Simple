using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DiagnosaMatrix.DeleteDiagnosaMatrix;

namespace SimpleCliniq.Module.Core.Presentation.DiagnosaMatrix;

public class DeleteDiagnosaMatrix : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.DiagnosaMatrix + "/{Id}", async (ISender sender, [AsParameters]DeleteDiagnosaMatrixCommand query) =>
        {
            Result<DeleteDiagnosaMatrixResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteDiagnosaMatrix")
        .WithTags(Tags.DiagnosaMatrix)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

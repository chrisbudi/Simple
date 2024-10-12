using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.DiagnosaMatrix;

public class GetAllDiagnosaMatrix : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.DiagnosaMatrix, async (ISender sender, [AsParameters]GetAllDiagnosaMatrixQuery query) =>
        {
            Result<GetAllDiagnosaMatrixResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetAllDiagnosaMatrix")
        .WithTags(Tags.DiagnosaMatrix)
        .Produces<MDiagnosaMatrix[]>(StatusCodes.Status200OK);
    }
}

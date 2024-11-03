using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.DeleteLaboratoriumRekanan;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumRekanan;

public class DeleteLaboratoriumRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.LaboratoriumRekanan+ "/{Id}", async (ISender sender, [AsParameters]DeleteLaboratoriumRekananCommand query) =>
        {
            Result<DeleteLaboratoriumRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteLaboratoriumRekanan")
        .WithTags(Tags.LaboratoriumRekanan)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

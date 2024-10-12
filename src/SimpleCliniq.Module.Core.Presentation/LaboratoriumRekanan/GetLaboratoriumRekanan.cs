using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.GetLaboratoriumRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumRekanan;

public class GetLaboratoriumRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.LaboratoriumRekanan + "/{id}", async (ISender sender, [AsParameters]GetLaboratoriumRekananQuery query) =>
        {
            Result<GetLaboratoriumRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetLaboratoriumRekananById")
        .WithTags(Tags.LaboratoriumRekanan)
        .Produces<MLaboratoriumRekanan>(StatusCodes.Status200OK);
    }
}

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumHarga.GetLaboratoriumHarga;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumHarga;

public class GetLaboratoriumHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.LaboratoriumHarga + "/{id}", async (ISender sender, [AsParameters]GetLaboratoriumHargaQuery query) =>
        {
            Result<GetLaboratoriumHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetLaboratoriumHargaById")
        .WithTags(Tags.LaboratoriumHarga)
        .Produces<MLaboratoriumHarga>(StatusCodes.Status200OK);
    }
}

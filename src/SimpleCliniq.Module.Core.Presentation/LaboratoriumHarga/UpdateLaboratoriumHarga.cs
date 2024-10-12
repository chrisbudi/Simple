using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumHarga.UpdateLaboratoriumHarga;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumHarga;

public class UpdateLaboratoriumHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.LaboratoriumHarga, async (ISender sender, [AsParameters]UpdateLaboratoriumHargaCommand query) =>
        {
            Result<UpdateLaboratoriumHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdateLaboratoriumHarga")
        .WithTags(Tags.LaboratoriumHarga)
        .Produces<MLaboratoriumHarga>(StatusCodes.Status200OK);
    }
}

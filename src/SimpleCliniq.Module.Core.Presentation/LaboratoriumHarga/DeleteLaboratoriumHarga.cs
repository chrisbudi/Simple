using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumHarga.DeleteLaboratoriumHarga;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumHarga;

public class DeleteLaboratoriumHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.LaboratoriumHarga, async (ISender sender, [AsParameters]DeleteLaboratoriumHargaCommand query) =>
        {
            Result<DeleteLaboratoriumHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeleteLaboratoriumHarga")
        .WithTags(Tags.LaboratoriumHarga)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

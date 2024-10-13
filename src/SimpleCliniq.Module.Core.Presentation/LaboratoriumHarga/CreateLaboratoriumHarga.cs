using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumHarga.CreateLaboratoriumHarga;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumHarga;

public class CreateLaboratoriumHarga : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.LaboratoriumHarga, async (ISender sender, [AsParameters]CreateLaboratoriumHargaCommand query) =>
        {
            Result<CreateLaboratoriumHargaResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateLaboratoriumHarga")
        .WithTags(Tags.LaboratoriumHarga)
        .Produces<MLaboratoriumHarga>(StatusCodes.Status200OK);
    }
}

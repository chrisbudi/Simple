using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.CreateLaboratoriumRekanan;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.LaboratoriumRekanan;

public class CreateLaboratoriumRekanan : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.LaboratoriumRekanan, async (ISender sender, [AsParameters]CreateLaboratoriumRekananCommand query) =>
        {
            Result<CreateLaboratoriumRekananResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreateLaboratoriumRekanan")
        .WithTags(Tags.LaboratoriumRekanan)
        .Produces<MLaboratoriumRekanan>(StatusCodes.Status200OK);
    }
}

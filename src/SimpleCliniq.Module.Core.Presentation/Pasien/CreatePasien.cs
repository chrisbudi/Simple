using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Pasien.CreatePasien;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Pasien;

public class CreatePasien : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(EndpointUrls.Pasien, async (ISender sender, [AsParameters]CreatePasienCommand query) =>
        {
            Result<CreatePasienResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("CreatePasien")
        .WithTags(Tags.Pasien)
        .Produces<MPasien>(StatusCodes.Status200OK);
    }
}

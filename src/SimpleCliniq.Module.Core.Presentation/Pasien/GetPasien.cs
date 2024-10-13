using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Pasien;
using SimpleCliniq.Module.Core.Application.Pasien.GetPasien;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Pasien;

public class GetPasien : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(EndpointUrls.Pasien + "/{id}", async (ISender sender, [AsParameters]GetPasienQuery query) =>
        {
            Result<GetPasienResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("GetPasienById")
        .WithTags(Tags.Pasien)
        .Produces<MPasien>(StatusCodes.Status200OK);
    }
}

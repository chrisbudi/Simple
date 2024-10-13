using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Pasien.UpdatePasien;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Presentation.Pasien;

public class UpdatePasien : IEndpoint
{   
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(EndpointUrls.Pasien, async (ISender sender, [AsParameters]UpdatePasienCommand query) =>
        {
            Result<UpdatePasienResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("UpdatePasien")
        .WithTags(Tags.Pasien)
        .Produces<MPasien>(StatusCodes.Status200OK);
    }
}

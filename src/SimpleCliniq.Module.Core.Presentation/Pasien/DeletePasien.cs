using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Simple.Common.Domain;
using Simple.Common.Presentation.Endpoints;
using Simple.Common.Presentation.Results;
using SimpleCliniq.Module.Core.Application.Pasien.DeletePasien;

namespace SimpleCliniq.Module.Core.Presentation.Pasien;

public class DeletePasien : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(EndpointUrls.Pasien + "/{Id}", async (ISender sender, [AsParameters]DeletePasienCommand query) =>
        {
            Result<DeletePasienResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithName("DeletePasien")
        .WithTags(Tags.Pasien)
        .Produces<int>(StatusCodes.Status200OK);
    }
}

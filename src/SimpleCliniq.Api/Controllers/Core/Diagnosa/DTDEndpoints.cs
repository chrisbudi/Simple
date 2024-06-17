using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace Controllers.Core.Diagnosa;

public class DTDEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/DTD").WithTags(nameof(MDtd));

        group.MapGet("/", async (SimpleClinicContext db, [FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit) =>
        {

            return await db.MDtd.Skip(page).Take(limit).ToListAsync();
        })
        .WithName("GetAllDTD")
        .WithOpenApi()
        .Produces<MDtd[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);
        })
        .WithName("GetDTDById")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDtd input) =>
        {
            // update db with input

            var dtd = await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);

            dtd = input;

            await db.SaveChangesAsync();
            return Results.Ok(dtd);
        })
        .WithName("UpdateDTD")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDtd model) =>
        {

            var dtd = db.MDtd.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(dtd);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateMDTD")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var dtd = await db.MDtd.FirstAsync(m => m.IdDtd == id);
            dtd.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteDTD")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status200OK);

    }
}

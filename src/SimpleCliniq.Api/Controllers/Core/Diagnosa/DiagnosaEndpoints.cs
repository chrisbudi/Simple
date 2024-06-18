using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace Controllers.Core.Diagnosa;

public class DiagnosaEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Diagnosa").WithTags(nameof(MDiagnosa));

        group.MapGet("/", async (SimpleClinicContext db, 
                [FromQuery(Name = "page")] int page, 
                [FromQuery(Name = "limit")] int limit,
                [FromQuery(Name = "search")] string? search = null,
                [FromQuery(Name = "sort")] string? sort = "asc"
            ) =>
        {
            if(sort == "asc")
            {

                return await db.MDiagnosa.
                Skip(page).
                Take(limit).
                OrderBy(d => d.NmDiagnosa).
                Where(d => EF.Functions.ILike(d.NmDiagnosa, "%" + search + "%")).
                ToListAsync();
            }
            else
            {
                return await db.MDiagnosa.
                Skip(page).
                Take(limit).
                OrderByDescending(d => d.NmDiagnosa).
                Where(d => EF.Functions.ILike(d.NmDiagnosa, "%" + search + "%")).
                ToListAsync();
            }
        })
        .WithName("GetAllDiagnosa")
        .WithOpenApi()
        .Produces<MDiagnosa[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDiagnosa.FirstOrDefaultAsync(m => m.IdDiagnosa == id);
        })
        .WithName("GetDiagnosaById")
        .WithOpenApi()
        .Produces<MDiagnosa>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDiagnosa input) =>
        {
            // update db with input

            var diag = await db.MDiagnosa.FirstOrDefaultAsync(m => m.IdDiagnosa == id);

            diag = input;

            await db.SaveChangesAsync();
            return Results.Ok(diag);
        })
        .WithName("UpdateDiagnosa")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDiagnosa model) =>
        {

            var diag = db.MDiagnosa.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(diag);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateMDiagnosa")
        .WithOpenApi()
        .Produces<MDiagnosa>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var diag = await db.MDiagnosa.FirstAsync(m => m.IdDiagnosa == id);
            diag.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteDiagnosa")
        .WithOpenApi()
        .Produces<MDiagnosa>(StatusCodes.Status200OK);

    }
}

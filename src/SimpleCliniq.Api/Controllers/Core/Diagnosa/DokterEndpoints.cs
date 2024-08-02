using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class DokterEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Dokter").WithTags(nameof(MDokter));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MDokter
                .Where(d => EF.Functions.ILike(d.NmDokter, "%" + par.search + "%") && d.IsAktif == true)
                .OrderByDynamic(par.order ?? "IdDokter", par.orderAsc);

                var list = await filtered
                .Skip((par.page - 1) * par.size)
                .Take(par.size)
                .ToListAsync();

                return Result.Success(new
                {
                    list,
                    count = await filtered.CountAsync()
                });
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        })
        .WithName("GetAllDokter")
        .WithOpenApi()
        .Produces<MDokter[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDokter.FirstOrDefaultAsync(m => m.IdDokter == id && m.IsAktif == true);
        })
        .WithName("GetDokter")
        .WithOpenApi()
        .Produces<MDokter>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDokter input) =>
        {
            // update db with input

            var dokter = await db.MDokter.FirstOrDefaultAsync(m => m.IdDokter == id);
            if(dokter != null)
            {
                dokter.NmDokter = input.NmDokter;
                dokter.KdDokter = input.KdDokter;
            }

            await db.SaveChangesAsync();
            return Results.Ok(dokter);
        })
        .WithName("UpdateDokter")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDokter model) =>
        {

            db.MDokter.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateDokter")
        .WithOpenApi()
        .Produces<MDokter>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var dokter = await db.MDokter.FirstAsync(m => m.IdDokter == id);
            dokter.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteDokter")
        .WithOpenApi()
        .Produces<MDokter>(StatusCodes.Status200OK);

    }

    public class ParamList
    {
        public int page { get; set; }
        public int size { get; set; }
        public string? search { get; set; } = "";
        public string? order { get; set; } = "";
        public bool orderAsc { get; set; } = true;
    };
}

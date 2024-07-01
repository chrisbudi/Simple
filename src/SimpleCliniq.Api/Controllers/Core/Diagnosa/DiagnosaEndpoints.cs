using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class DiagnosaEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Diagnosa").WithTags(nameof(MDiagnosa));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MDiagnosa
                .Where(d => EF.Functions.ILike(d.NmDiagnosa, "%" + par.search + "%") || d.IsAktif == true)
                .OrderByDynamic(par.order ?? "IdDiagnosa", par.orderAsc);

                var list = await filtered
                .Skip((par.page * par.size))
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
            if(diag != null)
            {
                diag.KdDiagnosa = input.KdDiagnosa;
                diag.NmDiagnosa = input.NmDiagnosa;
                diag.Ispenyakit = input.Ispenyakit;
                diag.KdDtd = input.KdDtd;
            }

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

    public class ParamList
    {
        public int page { get; set; }
        public int size { get; set; }
        public string? search { get; set; } = "";
        public string? order { get; set; } = "";
        public bool orderAsc { get; set; } = true;
    };
}

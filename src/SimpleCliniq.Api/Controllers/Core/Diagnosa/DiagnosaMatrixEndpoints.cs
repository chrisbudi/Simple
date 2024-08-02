using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class DiagnosaMatrixEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/DiagnosaMatrix").WithTags(nameof(MDiagnosaMatrix));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MDiagnosaMatrix
                .Where(d => d.IdRuangan == par.searchIdRuangan)
                .OrderByDynamic(par.order ?? "IdMatrixDiagnosa", par.orderAsc);

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
        .WithName("GetAllDiagnosaMatrix")
        .WithOpenApi()
        .Produces<MDiagnosaMatrix[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDiagnosaMatrix.FirstOrDefaultAsync(m => m.IdMatrixDiagnosa == id);
        })
        .WithName("GetDiagnosaMatrixById")
        .WithOpenApi()
        .Produces<MDiagnosaMatrix>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDiagnosaMatrix input) =>
        {
            // update db with input

            var diag = await db.MDiagnosaMatrix.FirstOrDefaultAsync(m => m.IdMatrixDiagnosa == id);
            if(diag != null)
            {
                diag.IdRuangan = input.IdRuangan;
                diag.KodeRuangan = input.KodeRuangan;
                diag.IdDiagnosa = input.IdDiagnosa;
                diag.KdDiagnosa = input.KdDiagnosa;
            }

            await db.SaveChangesAsync();
            return Results.Ok(diag);
        })
        .WithName("UpdateDiagnosaMatrix")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDiagnosaMatrix model) =>
        {

            db.MDiagnosaMatrix.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateDiagnosaMatrix")
        .WithOpenApi()
        .Produces<MDiagnosa>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var diag = await db.MDiagnosaMatrix.FirstAsync(m => m.IdMatrixDiagnosa == id);
            diag.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteDiagnosaMatrix")
        .WithOpenApi()
        .Produces<MDiagnosaMatrix>(StatusCodes.Status200OK);

    }

    public class ParamList
    {
        public int page { get; set; }
        public int size { get; set; }
        public long? searchIdRuangan{ get; set; }
        public string? order { get; set; } = "";
        public bool orderAsc { get; set; } = true;
    };
}

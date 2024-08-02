using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class RuangEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Ruang").WithTags(nameof(MRuang));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MRuang
                .Where(d => EF.Functions.ILike(d.Nama, "%" + par.search + "%"))
                .OrderByDynamic(par.order ?? "IdRuang", par.orderAsc);

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
        .WithName("GetAllRuang")
        .WithOpenApi()
        .Produces<MRuang[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MRuang.FirstOrDefaultAsync(m => m.IdRuang == id);
        })
        .WithName("GetRuang")
        .WithOpenApi()
        .Produces<MRuang>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MRuang input) =>
        {
            // update db with input

            var ruang = await db.MRuang.FirstOrDefaultAsync(m => m.IdRuang == id);
            if(ruang != null)
            {
                ruang.Nama = input.Nama;
                ruang.KodeRuangan = input.KodeRuangan;
            }

            await db.SaveChangesAsync();
            return Results.Ok(ruang);
        })
        .WithName("UpdateRuang")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MRuang model) =>
        {

            db.MRuang.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateRuang")
        .WithOpenApi()
        .Produces<MRuang>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var ruang = await db.MRuang.FirstAsync(m => m.IdRuang == id);
            ruang.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteRuang")
        .WithOpenApi()
        .Produces<MRuang>(StatusCodes.Status200OK);

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

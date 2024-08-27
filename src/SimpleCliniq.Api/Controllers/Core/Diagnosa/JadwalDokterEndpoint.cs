using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class JadwalDokter : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/JadwalDokter").WithTags(nameof(MJadwalDokter));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db) =>
        {
           try
            {
                var filtered = db.MJadwalDokter
                .Where(d => EF.Functions.ILike(d.NamaKlinik, "%" + par.search + "%") && d.IsAktif == true)
                .OrderByDynamic(par.order ?? "IdJadwal", par.orderAsc);

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
        .WithName("GetAllJadwalDokter")
        .WithOpenApi()
        .Produces<MJadwalDokter[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MJadwalDokter.FirstOrDefaultAsync(m => m.IdJadwal == id && m.IsAktif == true);
        })
        .WithName("GetJadwalDokter")
        .WithOpenApi()
        .Produces<MJadwalDokter>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MJadwalDokter input) =>
        {
            // update db with input
            if (input.IdJadwal == 0) input.IdJadwal = id;
            var result = db.MJadwalDokter.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateJadwalDokter")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MJadwalDokter model) =>
        {

            db.MJadwalDokter.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateJadwalDokter")
        .WithOpenApi()
        .Produces<MJadwalDokter>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var JadwalDokter = await db.MJadwalDokter.FirstAsync(m => m.IdJadwal == id);
            JadwalDokter.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteJadwalDokter")
        .WithOpenApi()
        .Produces<MJadwalDokter>(StatusCodes.Status200OK);
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

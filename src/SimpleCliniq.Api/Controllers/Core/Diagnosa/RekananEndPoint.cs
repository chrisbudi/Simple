using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class RekananEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/Rekanan").WithTags(nameof(MRekanan));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db) =>
        {
           try
            {
                var filtered = db.MRekanan
                .Where(d => EF.Functions.ILike(d.NmRekanan, "%" + par.search + "%"))
                .OrderByDynamic(par.order ?? "IdRekanan", par.orderAsc);

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
        .WithName("GetAllRekanan")
        .WithOpenApi()
        .Produces<MRekanan[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MRekanan
                .FirstOrDefaultAsync(m => m.IdRekanan == id && m.IsAktif == true);
        })
        .WithName("GetRekanan")
        .WithOpenApi()
        .Produces<MRekanan>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MRekanan input) =>
        {
            // update db with input
            if (input.IdRekanan == 0) input.IdRekanan = id;
            var result = db.MRekanan.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateRekanan")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MRekanan model) =>
        {

            db.MRekanan.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateRekanan")
        .WithOpenApi()
        .Produces<MRekanan>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var Rekanan = await db.MRekanan.FirstAsync(m => m.IdRekanan == id);
            Rekanan.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteRekanan")
        .WithOpenApi()
        .Produces<MRekanan>(StatusCodes.Status200OK);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class PasienEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Pasien").WithTags(nameof(MPasien));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MPasien
                .Where(d => EF.Functions.ILike(d.NamaPasien, "%" + par.search + "%") && d.IsAktif == true)
                .OrderByDynamic(par.order ?? "IdPasien", par.orderAsc);

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
        .WithName("GetAllPasien")
        .WithOpenApi()
        .Produces<MPasien[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Ulid id, SimpleClinicContext db) =>
        {
            return await db.MPasien.FirstOrDefaultAsync(m => m.IdPasien == id && m.IsAktif == true);
        })
        .WithName("GetPasienById")
        .WithOpenApi()
        .Produces<MPasien>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, Ulid id, MPasien input) =>
        {
            // update db with input
            if (input.IdPasien == Ulid.Empty) input.IdPasien = id;
            var result = db.MPasien.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdatePasien")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MPasien model) =>
        {
            model.IdPasien = Ulid.NewUlid();
            db.MPasien.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreatePasien")
        .WithOpenApi()
        .Produces<MPasien>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, Ulid id) =>
        {
            var pas = await db.MPasien.FirstAsync(m => m.IdPasien == id);
            pas.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeletePasien")
        .WithOpenApi()
        .Produces<MPasien>(StatusCodes.Status200OK);

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

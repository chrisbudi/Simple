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
                .Where(d => EF.Functions.ILike(d.NamaPasien, "%" + par.search + "%"))
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

        group.MapGet("/{id}", async (string id, SimpleClinicContext db) =>
        {
            return await db.MPasien.FirstOrDefaultAsync(m => m.IdPasien == id);
        })
        .WithName("GetPasienById")
        .WithOpenApi()
        .Produces<MPasien>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, string id, MPasien input) =>
        {
            // update db with input

            var pas = await db.MPasien.FirstOrDefaultAsync(m => m.IdPasien == id);
            if(pas != null)
            {
                pas.PasienNo = input.PasienNo;
                pas.NamaPasien = input.NamaPasien;
                pas.NamaKelPasien = input.NamaKelPasien;
                pas.Kelaminpasien = input.Kelaminpasien;
                pas.Tmptlahirpasien = input.Tmptlahirpasien;
                pas.Tgllahirpasien = input.Tgllahirpasien;
                pas.AgamaPasien = input.AgamaPasien;
                pas.StatusKwnpasien = input.StatusKwnpasien;
                pas.PendidikanPasien = input.PendidikanPasien;
                pas.PekerjaanPasien = input.PekerjaanPasien;
                pas.AlamatPekerjaan = input.AlamatPekerjaan;
                pas.TelpPekerjaan = input.TelpPekerjaan;
                pas.Noktpsimpasien = input.Noktpsimpasien;
                pas.JenisIdentitas = input.JenisIdentitas;
                pas.NoPenjamin = input.NoPenjamin;
                pas.AlamatPasien = input.AlamatPasien;

            }

            await db.SaveChangesAsync();
            return Results.Ok(pas);
        })
        .WithName("UpdatePasien")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MPasien model) =>
        {

            db.MPasien.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreatePasien")
        .WithOpenApi()
        .Produces<MPasien>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, string id) =>
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

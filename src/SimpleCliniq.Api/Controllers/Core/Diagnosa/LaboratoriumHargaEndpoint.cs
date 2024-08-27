using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class LaboratoriumHargaEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/LaboratoriumHarga").WithTags(nameof(MLaboratoriumHarga));

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MLaboratoriumHarga
                .Include(r => r.IdHargakamarNavigation)
                .Include(r => r.IdPemeriksaanLabNavigation)
                .Include(r => r.Rekanan)
                .FirstOrDefaultAsync(m => m.IdLabharga == id && m.IsAktif == true);
        })
        .WithName("GetLaboratoriumHarga")
        .WithOpenApi()
        .Produces<MLaboratoriumHarga>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MLaboratoriumHarga input) =>
        {
            // update db with input
            if (input.IdLabharga == 0) input.IdLabharga = id;
            var result = db.MLaboratoriumHarga.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateLaboratoriumHarga")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MLaboratoriumHarga model) =>
        {

            db.MLaboratoriumHarga.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateLaboratoriumHarga")
        .WithOpenApi()
        .Produces<MLaboratoriumHarga>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var LaboratoriumHarga = await db.MLaboratoriumHarga.FirstAsync(m => m.IdLabharga == id);
            LaboratoriumHarga.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteLaboratoriumHarga")
        .WithOpenApi()
        .Produces<MLaboratoriumHarga>(StatusCodes.Status200OK);
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

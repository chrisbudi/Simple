using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class HargaRekananEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/HargaRekanan").WithTags(nameof(MHargaRekanan));

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MHargaRekanan
                .Include(r => r.Barang)
                .Include(r => r.Rekanan)
                .FirstOrDefaultAsync(m => m.IdHargaRekanan == id);
        })
        .WithName("GetHargaRekanan")
        .WithOpenApi()
        .Produces<MHargaRekanan>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MHargaRekanan input) =>
        {
            // update db with input
            if (input.IdHargaRekanan == 0) input.IdHargaRekanan = id;
            var result = db.MHargaRekanan.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateHargaRekanan")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MHargaRekanan model) =>
        {

            db.MHargaRekanan.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateHargaRekanan")
        .WithOpenApi()
        .Produces<MHargaRekanan>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var HargaRekanan = await db.MHargaRekanan.FirstAsync(m => m.IdHargaRekanan == id);
            HargaRekanan.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteHargaRekanan")
        .WithOpenApi()
        .Produces<MHargaRekanan>(StatusCodes.Status200OK);
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

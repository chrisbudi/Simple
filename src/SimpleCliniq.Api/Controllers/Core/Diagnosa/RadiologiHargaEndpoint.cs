using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class RadiologiHargaEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/RadiologiHarga").WithTags(nameof(MRadiologiHarga));

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MRadiologiHarga
                .Include(r => r.IdHargakamarNavigation)
                .Include(r => r.IdPemeriksaanRadNavigation)
                .Include(r => r.Rekanan)
                .FirstOrDefaultAsync(m => m.IdRadHarga == id);
        })
        .WithName("GetRadiologiHarga")
        .WithOpenApi()
        .Produces<MRadiologiHarga>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MRadiologiHarga input) =>
        {
            // update db with input
            if (input.IdRadHarga == 0) input.IdRadHarga = id;
            var result = db.MRadiologiHarga.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateRadiologiHarga")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MRadiologiHarga model) =>
        {

            db.MRadiologiHarga.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateRadiologiHarga")
        .WithOpenApi()
        .Produces<MRadiologiHarga>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var RadiologiHarga = await db.MRadiologiHarga.FirstAsync(m => m.IdRadHarga == id);
            RadiologiHarga.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteRadiologiHarga")
        .WithOpenApi()
        .Produces<MRadiologiHarga>(StatusCodes.Status200OK);
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

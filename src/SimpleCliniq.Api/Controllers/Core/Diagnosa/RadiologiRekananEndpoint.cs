using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class RadiologiRekananEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/RadiologiRekanan").WithTags(nameof(MRadiologiRekanan));

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MRadiologiRekanan
                .Include(r => r.IdPemeriksaanRadNavigation)
                .Include(r => r.Rekanan)
                .FirstOrDefaultAsync(m => m.IdRadrekanan == id);
        })
        .WithName("GetRadiologiRekanan")
        .WithOpenApi()
        .Produces<MRadiologiRekanan>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MRadiologiRekanan input) =>
        {
            // update db with input
            if (input.IdRadrekanan == 0) input.IdRadrekanan = id;
            var result = db.MRadiologiRekanan.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateRadiologiRekanan")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MRadiologiRekanan model) =>
        {

            db.MRadiologiRekanan.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateRadiologiRekanan")
        .WithOpenApi()
        .Produces<MRadiologiRekanan>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var RadiologiRekanan = await db.MRadiologiRekanan.FirstAsync(m => m.IdRadrekanan == id);
            RadiologiRekanan.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteRadiologiRekanan")
        .WithOpenApi()
        .Produces<MRadiologiRekanan>(StatusCodes.Status200OK);
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

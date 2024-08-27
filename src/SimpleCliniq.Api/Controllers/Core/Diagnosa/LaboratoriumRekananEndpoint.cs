using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;

namespace SimpleCliniqApi.Controllers.Core.Diagnosa;

public class LaboratoriumRekananEndPoint : IEndpoint
{
    public void MapEndPoint(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/core/LaboratoriumRekanan").WithTags(nameof(MLaboratoriumRekanan));

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MLaboratoriumRekanan
                .Include(r => r.IdPemeriksaanLabNavigation)
                .Include(r => r.Rekanan)
                .FirstOrDefaultAsync(m => m.IdLabrekanan == id && m.IsAktif == true);
        })
        .WithName("GetLaboratoriumRekanan")
        .WithOpenApi()
        .Produces<MLaboratoriumRekanan>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MLaboratoriumRekanan input) =>
        {
            // update db with input
            if (input.IdLabrekanan == 0) input.IdLabrekanan = id;
            var result = db.MLaboratoriumRekanan.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateLaboratoriumRekanan")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MLaboratoriumRekanan model) =>
        {

            db.MLaboratoriumRekanan.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(model);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateLaboratoriumRekanan")
        .WithOpenApi()
        .Produces<MLaboratoriumRekanan>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var LaboratoriumRekanan = await db.MLaboratoriumRekanan.FirstAsync(m => m.IdLabrekanan == id);
            LaboratoriumRekanan.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteLaboratoriumRekanan")
        .WithOpenApi()
        .Produces<MLaboratoriumRekanan>(StatusCodes.Status200OK);
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

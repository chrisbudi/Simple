using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class DTDEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/DTD").WithTags(nameof(MDtd));

        group.MapGet("/", async ([AsParameters] ParamList par,
            SimpleClinicContext db) =>
        {

            var filtered = db.MDtd
            .Where(d => EF.Functions.ILike(d.NmDtd, "%" + par.search + "%"))
            .OrderByDynamic(par.order ?? "IdDtd", par.orderAsc);

            var list = await filtered
                .Skip((par.page * par.size))
                .Take(par.size)
                .ToListAsync();


            return Result.Success(new
            {
                list,
                count = await filtered.CountAsync()
            });

        })
        .WithName("GetAllDTD")
        .WithOpenApi()
        .Produces<MDtd[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);
        })
        .WithName("GetDTDById")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDtd input) =>
        {
            // update db with input

            var dtd = await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);

            dtd = input;

            await db.SaveChangesAsync();
            return Results.Ok(dtd);
        })
        .WithName("UpdateDTD")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDtd model) =>
        {

            var dtd = db.MDtd.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(dtd);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateMDTD")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var dtd = await db.MDtd.FirstAsync(m => m.IdDtd == id);
            dtd.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteDTD")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status200OK);
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

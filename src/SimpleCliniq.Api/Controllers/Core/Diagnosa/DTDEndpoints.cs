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
            try
            {
                var filtered = db.MDtd
                .Where(d => EF.Functions.ILike(d.NmDtd, "%" + par.search + "%") && d.IsAktif == true)
                .OrderByDynamic(par.order ?? "IdDtd", par.orderAsc);

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
        .WithName("GetAllDTD")
        .WithOpenApi()
        .Produces<MDtd[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id && m.IsAktif == true);
        })
        .WithName("GetDTDById")
        .WithOpenApi()
        .Produces<MDtd>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MDtd input) =>
        {
            // update db with input
            if (input.IdDtd == 0) input.IdDtd = id;
            var result = db.MDtd.Update(input);
            await db.SaveChangesAsync();
            return Results.Ok(result.Entity);
        })
        .WithName("UpdateDTD")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MDtd model) =>
        {
            try
            {
                db.MDtd.Add(model);
                await db.SaveChangesAsync();
                return Result.Success(model);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
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

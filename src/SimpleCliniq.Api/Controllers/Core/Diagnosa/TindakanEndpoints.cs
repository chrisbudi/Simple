using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class TindakanEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/tindakan").WithTags(nameof(MTindakan));

        group.MapGet("/", async ([AsParameters] ParamList par,
            SimpleClinicContext db) =>
        {
            try
            {
                var filtered = db.MTindakan
                .Where(d => EF.Functions.ILike(d.NmTindakan, "%" + par.search + "%"))
                .OrderByDynamic(par.order ?? "IdTindakan", par.orderAsc);

                var list = await filtered
                    .Skip((par.page * par.size))
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
        .WithName("GetAllTindakan")
        .WithOpenApi()
        .Produces<MTindakan[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MTindakan.FirstOrDefaultAsync(m => m.IdTindakan == id);
        })
        .WithName("GetTindakanById")
        .WithOpenApi()
        .Produces<MTindakan>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MTindakan input) =>
        {
            // update db with input

            var tindakan = await db.MTindakan.FirstOrDefaultAsync(m => m.IdTindakan == id);

            if(tindakan != null)
            {
                tindakan.KdTindakan = input.KdTindakan;
                tindakan.NmTindakan = input.NmTindakan;
                tindakan.NmPendek = input.NmPendek;
            }

            await db.SaveChangesAsync();
            return Results.Ok(tindakan);
        })
        .WithName("UpdateTindakan")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MTindakan model) =>
        {
            try
            {
                var tindakan = db.MTindakan.Add(model);
                await db.SaveChangesAsync();
                return Result.Success(tindakan);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        })
        .WithName("CreateMTindakan")
        .WithOpenApi()
        .Produces<MTindakan>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var tindakan = await db.MTindakan.FirstAsync(m => m.IdTindakan == id);
            tindakan.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteTindakan")
        .WithOpenApi()
        .Produces<MTindakan>(StatusCodes.Status200OK);
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

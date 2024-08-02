using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class SmfEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/smf").WithTags(nameof(MSmf));

        group.MapGet("/", async ([AsParameters] ParamList par,
            SimpleClinicContext db) =>
        {
            try
            {
                var filtered = db.MSmf
                .Where(d => EF.Functions.ILike(d.Nmsmf, "%" + par.search + "%"))
                .OrderByDynamic(par.order ?? "IdSmf", par.orderAsc);

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
        .WithName("GetAllSmf")
        .WithOpenApi()
        .Produces<MSmf[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MSmf.FirstOrDefaultAsync(m => m.IdSmf == id);
        })
        .WithName("GetSmfById")
        .WithOpenApi()
        .Produces<MSmf>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MSmf input) =>
        {
            // update db with input

            var smf = await db.MSmf.FirstOrDefaultAsync(m => m.IdSmf == id);

            if(smf != null)
            {
                smf.Kdsmf = input.Kdsmf;
                smf.Nmsmf = input.Nmsmf;
            }

            await db.SaveChangesAsync();
            return Results.Ok(smf);
        })
        .WithName("UpdateSmf")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MSmf model) =>
        {
            try
            {
                db.MSmf.Add(model);
                await db.SaveChangesAsync();
                return Result.Success(model);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        })
        .WithName("CreateMSmf")
        .WithOpenApi()
        .Produces<MSmf>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var smf = await db.MSmf.FirstAsync(m => m.IdSmf == id);
            smf.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteSmf")
        .WithOpenApi()
        .Produces<MSmf>(StatusCodes.Status200OK);
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

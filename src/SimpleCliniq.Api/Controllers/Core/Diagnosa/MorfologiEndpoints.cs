using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Presentation.Endpoints;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure;
using SimpleCliniqApi.Controllers.Core.Shared;

namespace Controllers.Core.Diagnosa;

public class MorfologiEndpoints : IEndpoint
{
    public async void MapEndPoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/Morfologi").WithTags(nameof(MMorfologi));

        group.MapGet("/", async ([AsParameters] ParamList par, SimpleClinicContext db
            ) =>
        {
           try
            {
                var filtered = db.MMorfologi
                .Join(
                    db.MDiagnosa,
                    mm => mm.KdDiagnosa,
                    md => md.KdDiagnosa,
                    (mm, md) => new
                    {
                        IdMorfologi = mm.IdMorfologi,
                        KdMorfologi = mm.KdMorfologi,
                        NmMorfologi = mm.NmMorfologi,
                        KdDiagnosa = mm.KdDiagnosa,
                        IdDiagnosa = mm.IdDiagnosa,
                        IsAktif = mm.IsAktif,
                        IdDiagnosaNavigation = md
                    }
                )
                .Where(d => EF.Functions.ILike(d.NmMorfologi, "%" + par.search + "%"))
                .OrderByDynamic(par.order ?? "IdMorfologi", par.orderAsc);

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
        .WithName("GetAllMorfologi")
        .WithOpenApi()
        .Produces<MMorfologi[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, SimpleClinicContext db) =>
        {
            return await db.MMorfologi.FirstOrDefaultAsync(m => m.IdMorfologi == id);
        })
        .WithName("GetMorfologiById")
        .WithOpenApi()
        .Produces<MMorfologi>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (SimpleClinicContext db, int id, MMorfologi input) =>
        {
            // update db with input

            var morf = await db.MMorfologi.FirstOrDefaultAsync(m => m.IdMorfologi == id);
            if(morf != null)
            {
                morf.KdMorfologi = input.KdMorfologi;
                morf.NmMorfologi = input.NmMorfologi;
                morf.KdDiagnosa = input.KdDiagnosa;
                morf.IdDiagnosa = input.IdDiagnosa;
            }

            await db.SaveChangesAsync();
            return Results.Ok(morf);
        })
        .WithName("UpdateMorfologi")
        .WithOpenApi()
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (SimpleClinicContext db, MMorfologi model) =>
        {

            var morf = db.MMorfologi.Add(model);
            await db.SaveChangesAsync();
            return Results.Ok(morf);


            //return Results.Created($"/api/MDtds/{model.ID}", model);
        })
        .WithName("CreateMorfologi")
        .WithOpenApi()
        .Produces<MMorfologi>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (SimpleClinicContext db, int id) =>
        {
            var morf = await db.MMorfologi.FirstAsync(m => m.IdMorfologi == id);
            morf.IsAktif = false;

            await db.SaveChangesAsync();
        })
        .WithName("DeleteMorfologi")
        .WithOpenApi()
        .Produces<MMorfologi>(StatusCodes.Status200OK);

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

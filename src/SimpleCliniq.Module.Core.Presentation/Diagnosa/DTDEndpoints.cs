using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SimpleCliniq.Module.Core.Domain.Models;
using Simple.Common.Presentation.Endpoints;
//using Microsoft.EntityFrameworkCore;
//using SimpleCliniq.Common.Presentation.Endpoints;
//using SimpleCliniq.Module.Core.Domain.Models;
//using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Presentation.Diagnosa;

public class DTDEndpoints : IEndpoint
{
    public async void MapEndpoint(IEndpointRouteBuilder builder)
    {

        var group = builder.MapGroup("/api/core/DTD").WithTags(nameof(MDtd));

        //group.MapGet("/", async (SimpleCliniqCoreContext db) =>
        //{

        //    return await db.MDtd.Skip(0).Take(10).ToListAsync();
        //})
        //.WithName("GetAllDTD")
        //.Produces<MDtd[]>(StatusCodes.Status200OK);

        //group.MapGet("/{id}", async (int id, SimpleCliniqCoreContext db) =>
        //{
        //    return await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);
        //})
        //.WithName("GetDTDById")
        //.Produces<MDtd>(StatusCodes.Status200OK);

        //group.MapPut("/{id}", async (SimpleCliniqCoreContext db, int id, MDtd input) =>
        //{
        //    // update db with input

        //    var dtd = await db.MDtd.FirstOrDefaultAsync(m => m.IdDtd == id);

        //    dtd = input;

        //    await db.SaveChangesAsync();
        //    return Results.Ok(dtd);
        //})
        //.WithName("UpdateDTD")
        //.Produces(StatusCodes.Status204NoContent);

        //group.MapPost("/", async (SimpleCliniqCoreContext db, MDtd model) =>
        //{

        //    var dtd = db.MDtd.Add(model);
        //    await db.SaveChangesAsync();
        //    return Results.Ok(dtd);

        //    //return Results.Created($"/api/MDtds/{model.ID}", model);
        //})
        //.WithName("CreateMDTD")
        //.Produces<MDtd>(StatusCodes.Status201Created);

        //group.MapDelete("/{id}", async (SimpleCliniqCoreContext db, int id) =>
        //{
        //    var dtd = await db.MDtd.FirstAsync(m => m.IdDtd == id);
        //    dtd.IsAktif = false;

        //    await db.SaveChangesAsync();
        //})
        //.WithName("DeleteDTD")
        //.Produces<MDtd>(StatusCodes.Status200OK);

    }
}
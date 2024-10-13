using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class TindakanRepository(CoreDbContext db) : ITindakanRepository
{
    public async Task<MTindakan> Create(MTindakan model)
    {
        db.MTindakan.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Tindakan = await Get(id);
        Tindakan.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MTindakan> Get(int id)
    {
        return await db.MTindakan.FirstAsync(m => m.IdTindakan == id);
    }

    public async Task<GetAllResult<MTindakan>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MTindakan
            .Where(d => EF.Functions.ILike(d.NmTindakan, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MTindakan>(list, await filtered.CountAsync());
    }

    public async Task<MTindakan> Update(MTindakan model)
    {
        db.MTindakan.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

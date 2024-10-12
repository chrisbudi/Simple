using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class SmfRepository(CoreDbContext db) : ISmfRepository
{
    public async Task<MSmf> Create(MSmf model)
    {
        db.MSmf.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Smf = await Get(id);
        Smf.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MSmf> Get(int id)
    {
        return await db.MSmf.FirstAsync(m => m.IdSmf == id);
    }

    public async Task<GetAllResult<MSmf>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MSmf
            .Where(d => EF.Functions.ILike(d.Nmsmf, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MSmf>(list, await filtered.CountAsync());
    }

    public async Task<MSmf> Update(MSmf model)
    {
        db.MSmf.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class RuangRepository(CoreDbContext db) : IRuangRepository
{
    public async Task<MRuang> Create(MRuang model)
    {
        db.MRuang.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Ruang = await Get(id);
        Ruang.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MRuang> Get(int id)
    {
        return await db.MRuang.FirstAsync(m => m.IdRuang == id);
    }

    public async Task<GetAllResult<MRuang>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MRuang
            .Where(d => EF.Functions.ILike(d.Nama, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MRuang>(list, await filtered.CountAsync());
    }

    public async Task<MRuang> Update(MRuang model)
    {
        db.MRuang.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

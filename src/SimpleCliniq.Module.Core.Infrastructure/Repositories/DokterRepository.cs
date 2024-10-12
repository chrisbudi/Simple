using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class DokterRepository(CoreDbContext db) : IDokterRepository
{
    public async Task<MDokter> Create(MDokter model)
    {
        db.MDokter.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Dokter = await Get(id);
        Dokter.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MDokter> Get(int id)
    {
        return await db.MDokter.FirstAsync(m => m.IdDokter == id);
    }

    public async Task<GetAllResult<MDokter>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MDokter
            .Where(d => EF.Functions.ILike(d.NmDokter, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MDokter>(list, await filtered.CountAsync());
    }

    public async Task<MDokter> Update(MDokter model)
    {
        db.MDokter.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

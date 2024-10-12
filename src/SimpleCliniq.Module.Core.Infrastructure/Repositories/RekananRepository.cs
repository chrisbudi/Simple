using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class RekananRepository(CoreDbContext db) : IRekananRepository
{
    public async Task<MRekanan> Create(MRekanan model)
    {
        db.MRekanan.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Rekanan = await Get(id);
        Rekanan.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MRekanan> Get(int id)
    {
        return await db.MRekanan.FirstAsync(m => m.IdRekanan == id);
    }

    public async Task<GetAllResult<MRekanan>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MRekanan
            .Where(d => EF.Functions.ILike(d.NmRekanan, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MRekanan>(list, await filtered.CountAsync());
    }

    public async Task<MRekanan> Update(MRekanan model)
    {
        db.MRekanan.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

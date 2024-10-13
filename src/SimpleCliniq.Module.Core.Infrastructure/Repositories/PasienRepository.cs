using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class PasienRepository(CoreDbContext db) : IPasienRepository
{
    public async Task<MPasien> Create(MPasien model)
    {
        model.IdPasien = Guid.NewGuid();
        db.MPasien.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(Guid id)
    {
        var Pasien = await Get(id);
        Pasien.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MPasien> Get(Ulid id)
    {
        return await db.MPasien.FirstAsync(m => m.IdPasien == id);
    }

    public async Task<GetAllResult<MPasien>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MPasien
            .Where(d => EF.Functions.ILike(d.NamaPasien, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MPasien>(list, await filtered.CountAsync());
    }

    public async Task<MPasien> Update(MPasien model)
    {
        db.MPasien.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

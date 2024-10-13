using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class JadwalDokterRepository(CoreDbContext db) : IJadwalDokterRepository
{
    public async Task<MJadwalDokter> Create(MJadwalDokter model)
    {
        db.MJadwalDokter.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var JadwalDokter = await Get(id);
        JadwalDokter.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MJadwalDokter> Get(int id)
    {
        return await db.MJadwalDokter
            .Include(x => x.IdDokterNavigation)
            .Include(x => x.IdRuanganNavigation)
            .FirstAsync(m => m.IdJadwal == id);
    }

    public async Task<GetAllResult<MJadwalDokter>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MJadwalDokter
            .Include(x => x.IdDokterNavigation)
            .Where(d => EF.Functions.ILike(d.NamaKlinik, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MJadwalDokter>(list, await filtered.CountAsync());
    }

    public async Task<MJadwalDokter> Update(MJadwalDokter model)
    {
        db.MJadwalDokter.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

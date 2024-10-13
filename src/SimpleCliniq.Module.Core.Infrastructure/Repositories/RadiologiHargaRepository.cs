using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class RadiologiHargaRepository(CoreDbContext db) : IRadiologiHargaRepository
{
    public async Task<MRadiologiHarga> Create(MRadiologiHarga model)
    {
        db.MRadiologiHarga.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var RadiologiHarga = await Get(id);
        RadiologiHarga.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MRadiologiHarga> Get(int id)
    {
        return await db.MRadiologiHarga
            .Include(r => r.IdHargakamarNavigation)
            .Include(r => r.IdPemeriksaanRadNavigation)
            .Include(r => r.Rekanan)
            .FirstAsync(m => m.IdRadHarga == id);
    }
    
    public async Task<MRadiologiHarga> Update(MRadiologiHarga model)
    {
        db.MRadiologiHarga.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

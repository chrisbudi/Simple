using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class RadiologiRekananRepository(CoreDbContext db) : IRadiologiRekananRepository
{
    public async Task<MRadiologiRekanan> Create(MRadiologiRekanan model)
    {
        db.MRadiologiRekanan.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var RadiologiRekanan = await Get(id);
        RadiologiRekanan.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MRadiologiRekanan> Get(int id)
    {
        return await db.MRadiologiRekanan
            .Include(r => r.IdPemeriksaanRadNavigation)
            .Include(r => r.Rekanan)
            .FirstAsync(m => m.IdRadrekanan == id);
    }
    
    public async Task<MRadiologiRekanan> Update(MRadiologiRekanan model)
    {
        db.MRadiologiRekanan.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class LaboratoriumHargaRepository(CoreDbContext db) : ILaboratoriumHargaRepository
{
    public async Task<MLaboratoriumHarga> Create(MLaboratoriumHarga model)
    {
        db.MLaboratoriumHarga.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var LaboratoriumHarga = await Get(id);
        LaboratoriumHarga.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MLaboratoriumHarga> Get(int id)
    {
        return await db.MLaboratoriumHarga
            .Include(r => r.IdHargakamarNavigation)
            .Include(r => r.IdPemeriksaanLabNavigation)
            .Include(r => r.Rekanan)
            .FirstAsync(m => m.IdLabharga == id);
    }
    
    public async Task<MLaboratoriumHarga> Update(MLaboratoriumHarga model)
    {
        db.MLaboratoriumHarga.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class LaboratoriumRekananRepository(CoreDbContext db) : ILaboratoriumRekananRepository
{
    public async Task<MLaboratoriumRekanan> Create(MLaboratoriumRekanan model)
    {
        db.MLaboratoriumRekanan.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var LaboratoriumRekanan = await Get(id);
        LaboratoriumRekanan.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MLaboratoriumRekanan> Get(int id)
    {
        return await db.MLaboratoriumRekanan
            .Include(r => r.IdPemeriksaanLabNavigation)
            .Include(r => r.Rekanan)
            .FirstAsync(m => m.IdLabrekanan == id);
    }
    
    public async Task<MLaboratoriumRekanan> Update(MLaboratoriumRekanan model)
    {
        db.MLaboratoriumRekanan.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

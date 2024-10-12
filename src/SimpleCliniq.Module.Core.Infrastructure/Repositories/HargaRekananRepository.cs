using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class HargaRekananRepository(CoreDbContext db) : IHargaRekananRepository
{
    public async Task<MHargaRekanan> Create(MHargaRekanan model)
    {
        db.MHargaRekanan.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(Guid id)
    {
        var HargaRekanan = await Get(id);
        HargaRekanan.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MHargaRekanan> Get(Guid id)
    {
        return await db.MHargaRekanan.FirstAsync(m => m.IdHargaRekanan == id);
    }
    
    public async Task<MHargaRekanan> Update(MHargaRekanan model)
    {
        db.MHargaRekanan.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

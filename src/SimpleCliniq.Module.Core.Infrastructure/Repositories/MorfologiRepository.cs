using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class MorfologiRepository(CoreDbContext db) : IMorfologiRepository
{
    public async Task<MMorfologi> Create(MMorfologi model)
    {
        db.MMorfologi.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var Morfologi = await Get(id);
        Morfologi.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MMorfologi> Get(int id)
    {
        return await db.MMorfologi.FirstAsync(m => m.IdMorfologi == id);
    }

    public async Task<GetAllResult<MMorfologi>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        var filtered = db.MMorfologi
            .Include(m => m.IdDiagnosaNavigation)
            .Where(d => EF.Functions.ILike(d.NmMorfologi, "%" + search + "%") && d.IdDiagnosa != null && d.IsAktif == true)
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MMorfologi>(list, await filtered.CountAsync());
    }

    public async Task<MMorfologi> Update(MMorfologi model)
    {
        db.MMorfologi.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

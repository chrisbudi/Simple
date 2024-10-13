using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class DiagnosaRepository(CoreDbContext db) : IDiagnosaRepository
{
    public async Task<MDiagnosa> Create(MDiagnosa model)
    {
        db.MDiagnosa.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var dtd = await Get(id);
        dtd.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MDiagnosa> Get(int id)
    {
        return await db.MDiagnosa.FirstAsync(m => m.IdDiagnosa == id);
    }

    public async Task<GetAllResult<MDiagnosa>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        order = !order.IsNullOrEmpty() ? order : "IdDiagnosa";
        var filtered = db.MDiagnosa
            .Where(d => EF.Functions.ILike(d.NmDiagnosa, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return new GetAllResult<MDiagnosa>(list, await filtered.CountAsync());
    }

    public async Task<MDiagnosa> Update(MDiagnosa model)
    {
        db.MDiagnosa.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

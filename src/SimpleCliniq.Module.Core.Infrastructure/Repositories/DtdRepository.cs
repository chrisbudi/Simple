using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class DtdRepository(CoreDbContext db) : IDtdRepository
{
    public async Task<MDtd> Create(MDtd model)
    {
        await db.MDtd.AddAsync(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var dtd = await Get(id);
        dtd.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MDtd> Get(int id)
    {
        return await db.MDtd.FirstAsync(m => m.IdDtd == id);
    }

    public async Task<GetAllResult<MDtd>> GetAll(int page, int size, string? search = "", string order = "", bool orderAsc = true)
    {
        order = !order.IsNullOrEmpty() ? order : "IdDtd";
        var filtered = db.MDtd
            .Where(d => EF.Functions.ILike(d.NmDtd, "%" + search + "%"))
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new GetAllResult<MDtd>(list, await filtered.CountAsync());
    }

    public async Task<MDtd> Update(MDtd model)
    {
        db.MDtd.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

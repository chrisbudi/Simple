using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniq.Module.Core.Infrastructure.Repositories;

public class DiagnosaMatrixRepository(CoreDbContext db) : IDiagnosaMatrixRepository
{
    public async Task<MDiagnosaMatrix> Create(MDiagnosaMatrix model)
    {
        db.MDiagnosaMatrix.Add(model);
        await db.SaveChangesAsync();
        return model;
    }

    public async Task Delete(int id)
    {
        var dtd = await Get(id);
        dtd.IsAktif = false;

        await db.SaveChangesAsync();
    }

    public async Task<MDiagnosaMatrix> Get(int id)
    {
        return await db.MDiagnosaMatrix.FirstAsync(m => m.IdMatrixDiagnosa == id);
    }

    public async Task<GetAllResult<MDiagnosaMatrix>> GetAll(int page, int size, long? searchIdRuangan = 0, string order = "", bool orderAsc = true)
    {
        var filtered = db.MDiagnosaMatrix
            .Where(d => d.IdRuangan == searchIdRuangan)
            .OrderByDynamic(order, orderAsc);

        var list = await filtered
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return new GetAllResult<MDiagnosaMatrix>(list, await filtered.CountAsync());
    }

    public async Task<MDiagnosaMatrix> Update(MDiagnosaMatrix model)
    {
        db.MDiagnosaMatrix.Update(model);
        await db.SaveChangesAsync();
        return model;
    }
}

using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IDokterRepository
{
    public Task<GetAllResult<MDokter>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MDokter> Get(int id);
    public Task<MDokter> Create(MDokter model);
    public Task<MDokter> Update(MDokter model);    
    public Task Delete(int id);    
}

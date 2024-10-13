using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IDtdRepository
{
    public Task<GetAllResult<MDtd>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MDtd> Get(int id);
    public Task<MDtd> Create(MDtd model);
    public Task<MDtd> Update(MDtd model);    
    public Task Delete(int id);    
}

using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface ITindakanRepository
{
    public Task<GetAllResult<MTindakan>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MTindakan> Get(int id);
    public Task<MTindakan> Create(MTindakan model);
    public Task<MTindakan> Update(MTindakan model);    
    public Task Delete(int id);    
}

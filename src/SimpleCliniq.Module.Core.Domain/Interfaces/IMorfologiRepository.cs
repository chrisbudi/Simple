using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IMorfologiRepository
{
    public Task<GetAllResult<MMorfologi>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MMorfologi> Get(int id);
    public Task<MMorfologi> Create(MMorfologi model);
    public Task<MMorfologi> Update(MMorfologi model);    
    public Task Delete(int id);    
}

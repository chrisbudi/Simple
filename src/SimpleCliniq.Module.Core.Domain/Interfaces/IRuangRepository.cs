using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IRuangRepository
{
    public Task<GetAllResult<MRuang>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MRuang> Get(int id);
    public Task<MRuang> Create(MRuang model);
    public Task<MRuang> Update(MRuang model);    
    public Task Delete(int id);    
}

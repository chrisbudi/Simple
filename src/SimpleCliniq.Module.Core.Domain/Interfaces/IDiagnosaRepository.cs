using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IDiagnosaRepository
{
    public Task<GetAllResult<MDiagnosa>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MDiagnosa> Get(int id);
    public Task<MDiagnosa> Create(MDiagnosa model);
    public Task<MDiagnosa> Update(MDiagnosa model);    
    public Task Delete(int id);    
}

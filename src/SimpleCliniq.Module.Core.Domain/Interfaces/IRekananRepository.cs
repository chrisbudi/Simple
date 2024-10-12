using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IRekananRepository
{
    public Task<GetAllResult<MRekanan>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MRekanan> Get(int id);
    public Task<MRekanan> Create(MRekanan model);
    public Task<MRekanan> Update(MRekanan model);    
    public Task Delete(int id);    
}

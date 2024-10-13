using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface ISmfRepository
{
    public Task<GetAllResult<MSmf>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MSmf> Get(int id);
    public Task<MSmf> Create(MSmf model);
    public Task<MSmf> Update(MSmf model);    
    public Task Delete(int id);    
}

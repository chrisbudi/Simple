using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IPasienRepository
{
    public Task<GetAllResult<MPasien>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MPasien> Get(Ulid id);
    public Task<MPasien> Create(MPasien model);
    public Task<MPasien> Update(MPasien model);    
    public Task Delete(Ulid id);    
}

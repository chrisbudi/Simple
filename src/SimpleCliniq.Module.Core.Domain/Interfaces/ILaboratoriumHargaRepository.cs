using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface ILaboratoriumHargaRepository
{
    public Task<MLaboratoriumHarga> Get(int id);
    public Task<MLaboratoriumHarga> Create(MLaboratoriumHarga model);
    public Task<MLaboratoriumHarga> Update(MLaboratoriumHarga model);    
    public Task Delete(int id);    
}

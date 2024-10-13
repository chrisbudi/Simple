using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface ILaboratoriumRekananRepository
{
    public Task<MLaboratoriumRekanan> Get(int id);
    public Task<MLaboratoriumRekanan> Create(MLaboratoriumRekanan model);
    public Task<MLaboratoriumRekanan> Update(MLaboratoriumRekanan model);    
    public Task Delete(int id);    
}

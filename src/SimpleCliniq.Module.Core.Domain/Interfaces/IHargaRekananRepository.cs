using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IHargaRekananRepository
{
    public Task<MHargaRekanan> Get(Guid id);
    public Task<MHargaRekanan> Create(MHargaRekanan model);
    public Task<MHargaRekanan> Update(MHargaRekanan model);    
    public Task Delete(Guid id);    
}

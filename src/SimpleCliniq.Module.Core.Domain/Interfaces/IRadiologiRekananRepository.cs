using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IRadiologiRekananRepository
{
    public Task<MRadiologiRekanan> Get(int id);
    public Task<MRadiologiRekanan> Create(MRadiologiRekanan model);
    public Task<MRadiologiRekanan> Update(MRadiologiRekanan model);    
    public Task Delete(int id);    
}

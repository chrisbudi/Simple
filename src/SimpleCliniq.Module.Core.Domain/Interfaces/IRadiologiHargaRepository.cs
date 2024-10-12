using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IRadiologiHargaRepository
{
    public Task<MRadiologiHarga> Get(int id);
    public Task<MRadiologiHarga> Create(MRadiologiHarga model);
    public Task<MRadiologiHarga> Update(MRadiologiHarga model);    
    public Task Delete(int id);    
}

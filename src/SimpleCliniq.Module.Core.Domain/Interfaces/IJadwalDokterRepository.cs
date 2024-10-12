using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IJadwalDokterRepository
{
    public Task<GetAllResult<MJadwalDokter>> GetAll(int page, int size, string? search ="", string order = "", bool orderAsc = true);
    public Task<MJadwalDokter> Get(int id);
    public Task<MJadwalDokter> Create(MJadwalDokter model);
    public Task<MJadwalDokter> Update(MJadwalDokter model);    
    public Task Delete(int id);    
}

using SimpleCliniq.Module.Core.Domain.Dtos;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Domain.Interfaces;

public interface IDiagnosaMatrixRepository
{
    public Task<GetAllResult<MDiagnosaMatrix>> GetAll(int page, int size, long? searchIdRuangan = 0, string order = "", bool orderAsc = true);
    public Task<MDiagnosaMatrix> Get(int id);
    public Task<MDiagnosaMatrix> Create(MDiagnosaMatrix model);
    public Task<MDiagnosaMatrix> Update(MDiagnosaMatrix model);    
    public Task Delete(int id);    
}

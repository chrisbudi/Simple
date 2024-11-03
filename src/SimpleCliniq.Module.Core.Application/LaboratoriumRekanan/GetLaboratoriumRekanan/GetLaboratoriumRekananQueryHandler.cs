using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.GetLaboratoriumRekanan;

internal sealed class GetLaboratoriumRekananQueryHandler(ILaboratoriumRekananRepository repository)
    : IQueryHandler<GetLaboratoriumRekananQuery, GetLaboratoriumRekananResponse>
{
    public async Task<Result<GetLaboratoriumRekananResponse>> Handle(GetLaboratoriumRekananQuery request, CancellationToken cancellationToken)
    {
        MLaboratoriumRekanan response = await repository.Get(request.Id);
        return new GetLaboratoriumRekananResponse(response);
    }
}
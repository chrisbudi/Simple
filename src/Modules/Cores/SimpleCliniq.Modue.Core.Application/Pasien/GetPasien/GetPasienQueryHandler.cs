using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

internal sealed class GetPasienQueryHandler(IPasienRepository repository)
    : IQueryHandler<GetPasienQuery, GetPasienResponse>
{
    public async Task<Result<GetPasienResponse>> Handle(GetPasienQuery request, CancellationToken cancellationToken)
    {
        MPasien response = await repository.Get(request.Id);
        return new GetPasienResponse(response);
    }
}
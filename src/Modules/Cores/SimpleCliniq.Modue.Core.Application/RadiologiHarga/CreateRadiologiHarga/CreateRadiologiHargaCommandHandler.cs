using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.CreateRadiologiHarga;

internal sealed class CreateRadiologiHargaCommandHandler(IRadiologiHargaRepository repository)
    : ICommandHandler<CreateRadiologiHargaCommand, CreateRadiologiHargaResponse>
{
    public async Task<Result<CreateRadiologiHargaResponse>> Handle(CreateRadiologiHargaCommand request, CancellationToken cancellationToken)
    {
        MRadiologiHarga model = await repository.Create(request.Data);
        return new CreateRadiologiHargaResponse(model);
    }
}
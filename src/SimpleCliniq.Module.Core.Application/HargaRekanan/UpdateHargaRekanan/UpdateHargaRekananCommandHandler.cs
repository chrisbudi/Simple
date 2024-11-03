using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.UpdateHargaRekanan;

internal sealed class UpdateHargaRekananCommandHandler(IHargaRekananRepository repository)
    : ICommandHandler<UpdateHargaRekananCommand, UpdateHargaRekananResponse>
{
    public async Task<Result<UpdateHargaRekananResponse>> Handle(UpdateHargaRekananCommand request, CancellationToken cancellationToken)
    {
        MHargaRekanan model = await repository.Update(request.Data);
        return new UpdateHargaRekananResponse(model);
    }
}
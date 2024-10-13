using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.CreateHargaRekanan;

internal sealed class CreateHargaRekananCommandHandler(IHargaRekananRepository repository)
    : ICommandHandler<CreateHargaRekananCommand, CreateHargaRekananResponse>
{
    public async Task<Result<CreateHargaRekananResponse>> Handle(CreateHargaRekananCommand request, CancellationToken cancellationToken)
    {
        MHargaRekanan model = await repository.Create(request.Data);
        return new CreateHargaRekananResponse(model);
    }
}
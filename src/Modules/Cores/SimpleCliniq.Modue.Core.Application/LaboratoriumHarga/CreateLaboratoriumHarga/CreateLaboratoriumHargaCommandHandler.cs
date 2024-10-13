using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.CreateLaboratoriumHarga;

internal sealed class CreateLaboratoriumHargaCommandHandler(ILaboratoriumHargaRepository repository)
    : ICommandHandler<CreateLaboratoriumHargaCommand, CreateLaboratoriumHargaResponse>
{
    public async Task<Result<CreateLaboratoriumHargaResponse>> Handle(CreateLaboratoriumHargaCommand request, CancellationToken cancellationToken)
    {
        MLaboratoriumHarga model = await repository.Create(request.Data);
        return new CreateLaboratoriumHargaResponse(model);
    }
}
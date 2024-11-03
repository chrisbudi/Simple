using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.UpdateLaboratoriumRekanan;

internal sealed class UpdateLaboratoriumRekananCommandHandler(ILaboratoriumRekananRepository repository)
    : ICommandHandler<UpdateLaboratoriumRekananCommand, UpdateLaboratoriumRekananResponse>
{
    public async Task<Result<UpdateLaboratoriumRekananResponse>> Handle(UpdateLaboratoriumRekananCommand request, CancellationToken cancellationToken)
    {
        MLaboratoriumRekanan model = await repository.Update(request.Data);
        return new UpdateLaboratoriumRekananResponse(model);
    }
}
using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.CreateLaboratoriumRekanan;

internal sealed class CreateLaboratoriumRekananCommandHandler(ILaboratoriumRekananRepository repository)
    : ICommandHandler<CreateLaboratoriumRekananCommand, CreateLaboratoriumRekananResponse>
{
    public async Task<Result<CreateLaboratoriumRekananResponse>> Handle(CreateLaboratoriumRekananCommand request, CancellationToken cancellationToken)
    {
        MLaboratoriumRekanan model = await repository.Create(request.Data);
        return new CreateLaboratoriumRekananResponse(model);
    }
}
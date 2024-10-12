using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.CreateRadiologiRekanan;

internal sealed class CreateRadiologiRekananCommandHandler(IRadiologiRekananRepository repository)
    : ICommandHandler<CreateRadiologiRekananCommand, CreateRadiologiRekananResponse>
{
    public async Task<Result<CreateRadiologiRekananResponse>> Handle(CreateRadiologiRekananCommand request, CancellationToken cancellationToken)
    {
        MRadiologiRekanan model = await repository.Create(request.Data);
        return new CreateRadiologiRekananResponse(model);
    }
}
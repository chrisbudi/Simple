using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.UpdateRadiologiRekanan;

internal sealed class UpdateRadiologiRekananCommandHandler(IRadiologiRekananRepository repository)
    : ICommandHandler<UpdateRadiologiRekananCommand, UpdateRadiologiRekananResponse>
{
    public async Task<Result<UpdateRadiologiRekananResponse>> Handle(UpdateRadiologiRekananCommand request, CancellationToken cancellationToken)
    {
        MRadiologiRekanan model = await repository.Update(request.Data);
        return new UpdateRadiologiRekananResponse(model);
    }
}
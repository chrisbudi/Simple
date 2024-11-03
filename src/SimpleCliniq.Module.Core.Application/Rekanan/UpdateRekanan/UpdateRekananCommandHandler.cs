using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.UpdateRekanan;

internal sealed class UpdateRekananCommandHandler(IRekananRepository repository)
    : ICommandHandler<UpdateRekananCommand, UpdateRekananResponse>
{
    public async Task<Result<UpdateRekananResponse>> Handle(UpdateRekananCommand request, CancellationToken cancellationToken)
    {
        MRekanan model = await repository.Update(request.Data);
        return new UpdateRekananResponse(model);
    }
}
using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.CreateRekanan;

internal sealed class CreateRekananCommandHandler(IRekananRepository repository)
    : ICommandHandler<CreateRekananCommand, CreateRekananResponse>
{
    public async Task<Result<CreateRekananResponse>> Handle(CreateRekananCommand request, CancellationToken cancellationToken)
    {
        MRekanan model = await repository.Create(request.Data);
        return new CreateRekananResponse(model);
    }
}
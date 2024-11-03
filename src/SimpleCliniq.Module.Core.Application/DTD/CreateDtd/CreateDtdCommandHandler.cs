using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.DTD.CreateDtd;

internal sealed class CreateDtdCommandHandler(IDtdRepository repository)
    : ICommandHandler<CreateDtdCommand, CreateDtdResponse>
{
    public async Task<Result<CreateDtdResponse>> Handle(CreateDtdCommand request, CancellationToken cancellationToken)
    {
        MDtd model = await repository.Create(request.Data);
        return new CreateDtdResponse(model);
    }
}
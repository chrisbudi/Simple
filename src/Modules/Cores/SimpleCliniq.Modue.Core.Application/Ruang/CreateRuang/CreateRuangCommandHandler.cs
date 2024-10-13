using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.CreateRuang;

internal sealed class CreateRuangCommandHandler(IRuangRepository repository)
    : ICommandHandler<CreateRuangCommand, CreateRuangResponse>
{
    public async Task<Result<CreateRuangResponse>> Handle(CreateRuangCommand request, CancellationToken cancellationToken)
    {
        MRuang model = await repository.Create(request.Data);
        return new CreateRuangResponse(model);
    }
}
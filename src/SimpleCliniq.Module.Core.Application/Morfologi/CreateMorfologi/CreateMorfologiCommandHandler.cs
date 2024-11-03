using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.CreateMorfologi;

internal sealed class CreateMorfologiCommandHandler(IMorfologiRepository repository)
    : ICommandHandler<CreateMorfologiCommand, CreateMorfologiResponse>
{
    public async Task<Result<CreateMorfologiResponse>> Handle(CreateMorfologiCommand request, CancellationToken cancellationToken)
    {
        MMorfologi model = await repository.Create(request.Data);
        return new CreateMorfologiResponse(model);
    }
}
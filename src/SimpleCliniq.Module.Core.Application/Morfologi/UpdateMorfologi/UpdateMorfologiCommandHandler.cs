using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.UpdateMorfologi;

internal sealed class UpdateMorfologiCommandHandler(IMorfologiRepository repository)
    : ICommandHandler<UpdateMorfologiCommand, UpdateMorfologiResponse>
{
    public async Task<Result<UpdateMorfologiResponse>> Handle(UpdateMorfologiCommand request, CancellationToken cancellationToken)
    {
        MMorfologi model = await repository.Update(request.Data);
        return new UpdateMorfologiResponse(model);
    }
}
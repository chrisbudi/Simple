using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Application.Morfologi.DeleteMorfologi;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Morfologi.DeleteMorfologi;

internal sealed class DeleteMorfologiCommandHandler(IMorfologiRepository repository)
    : ICommandHandler<DeleteMorfologiCommand, DeleteMorfologiResponse>
{
    public async Task<Result<DeleteMorfologiResponse>> Handle(DeleteMorfologiCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteMorfologiResponse(request.Id);
    }
}
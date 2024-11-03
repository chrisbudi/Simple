using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;

namespace SimpleCliniq.Module.Core.Application.Ruang.DeleteRuang;

internal sealed class DeleteRuangCommandHandler(IRuangRepository repository)
    : ICommandHandler<DeleteRuangCommand, DeleteRuangResponse>
{
    public async Task<Result<DeleteRuangResponse>> Handle(DeleteRuangCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.Id);
        return new DeleteRuangResponse(request.Id);
    }
}
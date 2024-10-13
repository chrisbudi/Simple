using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;

internal sealed class GetMorfologiQueryHandler(IMorfologiRepository repository)
    : IQueryHandler<GetMorfologiQuery, GetMorfologiResponse>
{
    public async Task<Result<GetMorfologiResponse>> Handle(GetMorfologiQuery request, CancellationToken cancellationToken)
    {
        MMorfologi response = await repository.Get(request.Id);
        return new GetMorfologiResponse(response);
    }
}
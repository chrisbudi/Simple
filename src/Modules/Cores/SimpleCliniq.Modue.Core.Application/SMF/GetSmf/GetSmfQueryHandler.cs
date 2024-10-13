using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.SMF.GetSmf;

internal sealed class GetSmfQueryHandler(ISmfRepository repository)
    : IQueryHandler<GetSmfQuery, GetSmfResponse>
{
    public async Task<Result<GetSmfResponse>> Handle(GetSmfQuery request, CancellationToken cancellationToken)
    {
        MSmf response = await repository.Get(request.Id);
        return new GetSmfResponse(response);
    }
}
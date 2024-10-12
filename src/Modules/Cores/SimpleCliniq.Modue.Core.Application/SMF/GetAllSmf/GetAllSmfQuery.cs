using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.SMF.GetSmf;

public sealed record GetAllSmfQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllSmfResponse>;
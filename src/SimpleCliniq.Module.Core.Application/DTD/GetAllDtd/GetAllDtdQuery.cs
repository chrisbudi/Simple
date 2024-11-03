using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DTD.GetDtd;

public sealed record GetAllDtdQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllDtdResponse>;
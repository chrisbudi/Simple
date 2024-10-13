using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Ruang.GetRuang;

public sealed record GetAllRuangQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllRuangResponse>;
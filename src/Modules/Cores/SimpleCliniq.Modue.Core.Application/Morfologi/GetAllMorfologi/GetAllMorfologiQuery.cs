using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;

public sealed record GetAllMorfologiQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllMorfologiResponse>;
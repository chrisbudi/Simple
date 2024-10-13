using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;

public sealed record GetAllDiagnosaQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllDiagnosaResponse>;
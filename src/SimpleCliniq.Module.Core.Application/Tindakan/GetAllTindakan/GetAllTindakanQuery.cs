using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;

public sealed record GetAllTindakanQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllTindakanResponse>;
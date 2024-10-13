using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

public sealed record GetAllPasienQuery(
    int Page,
    int Size,
    string Search = "",
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllPasienResponse>;
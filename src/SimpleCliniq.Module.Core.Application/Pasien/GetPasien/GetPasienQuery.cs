using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

public sealed record GetPasienQuery(
    Ulid Id
) : IQuery<GetPasienResponse>;
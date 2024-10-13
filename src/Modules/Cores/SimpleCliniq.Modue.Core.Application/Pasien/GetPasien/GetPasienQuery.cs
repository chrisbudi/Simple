using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Pasien.GetPasien;

public sealed record GetPasienQuery(
    Guid Id
) : IQuery<GetPasienResponse>;
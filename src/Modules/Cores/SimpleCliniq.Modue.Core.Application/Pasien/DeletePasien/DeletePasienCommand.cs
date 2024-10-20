using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Pasien.DeletePasien;

public sealed record DeletePasienCommand(Ulid Id) : ICommand<DeletePasienResponse>;
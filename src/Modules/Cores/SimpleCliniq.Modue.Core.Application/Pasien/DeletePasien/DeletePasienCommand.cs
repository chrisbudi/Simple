using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Pasien.DeletePasien;

public sealed record DeletePasienCommand(Guid Id) : ICommand<DeletePasienResponse>;
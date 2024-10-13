using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Dokter.DeleteDokter;

public sealed record DeleteDokterCommand(int Id) : ICommand<DeleteDokterResponse>;
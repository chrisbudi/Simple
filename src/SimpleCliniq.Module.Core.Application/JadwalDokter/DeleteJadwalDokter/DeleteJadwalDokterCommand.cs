using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.DeleteJadwalDokter;

public sealed record DeleteJadwalDokterCommand(int Id) : ICommand<DeleteJadwalDokterResponse>;
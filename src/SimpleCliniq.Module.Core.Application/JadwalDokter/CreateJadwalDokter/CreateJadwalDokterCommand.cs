using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.CreateJadwalDokter;

public sealed record CreateJadwalDokterCommand(MJadwalDokter Data) : ICommand<CreateJadwalDokterResponse>;
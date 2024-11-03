using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.JadwalDokter.UpdateJadwalDokter;

public sealed record UpdateJadwalDokterCommand(MJadwalDokter Data) : ICommand<UpdateJadwalDokterResponse>;
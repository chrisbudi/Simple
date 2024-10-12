using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.UpdateDokter;

public sealed record UpdateDokterCommand(MDokter Data) : ICommand<UpdateDokterResponse>;
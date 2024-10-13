using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Dokter.CreateDokter;

public sealed record CreateDokterCommand(MDokter Data) : ICommand<CreateDokterResponse>;
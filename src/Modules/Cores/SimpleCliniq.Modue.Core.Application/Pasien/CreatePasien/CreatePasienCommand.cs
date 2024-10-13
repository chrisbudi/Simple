using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.CreatePasien;

public sealed record CreatePasienCommand(MPasien Data) : ICommand<CreatePasienResponse>;
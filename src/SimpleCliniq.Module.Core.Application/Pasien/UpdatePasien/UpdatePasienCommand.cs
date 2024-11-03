using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Pasien.UpdatePasien;

public sealed record UpdatePasienCommand(MPasien Data) : ICommand<UpdatePasienResponse>;
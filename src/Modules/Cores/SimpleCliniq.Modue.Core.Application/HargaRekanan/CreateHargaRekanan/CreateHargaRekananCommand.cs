using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.CreateHargaRekanan;

public sealed record CreateHargaRekananCommand(MHargaRekanan Data) : ICommand<CreateHargaRekananResponse>;
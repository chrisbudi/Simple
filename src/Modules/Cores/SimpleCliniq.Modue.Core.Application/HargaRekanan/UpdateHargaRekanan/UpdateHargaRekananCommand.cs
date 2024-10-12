using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.UpdateHargaRekanan;

public sealed record UpdateHargaRekananCommand(MHargaRekanan Data) : ICommand<UpdateHargaRekananResponse>;
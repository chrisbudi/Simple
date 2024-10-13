using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.DeleteHargaRekanan;

public sealed record DeleteHargaRekananCommand(Guid Id) : ICommand<DeleteHargaRekananResponse>;
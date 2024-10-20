using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.HargaRekanan.DeleteHargaRekanan;

public sealed record DeleteHargaRekananCommand(Ulid Id) : ICommand<DeleteHargaRekananResponse>;
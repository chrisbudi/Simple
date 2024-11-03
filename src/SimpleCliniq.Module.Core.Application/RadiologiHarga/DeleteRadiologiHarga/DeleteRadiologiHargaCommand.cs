using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.DeleteRadiologiHarga;

public sealed record DeleteRadiologiHargaCommand(int Id) : ICommand<DeleteRadiologiHargaResponse>;
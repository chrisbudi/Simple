using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.CreateRadiologiHarga;

public sealed record CreateRadiologiHargaCommand(MRadiologiHarga Data) : ICommand<CreateRadiologiHargaResponse>;
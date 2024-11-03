using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiHarga.UpdateRadiologiHarga;

public sealed record UpdateRadiologiHargaCommand(MRadiologiHarga Data) : ICommand<UpdateRadiologiHargaResponse>;
using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.UpdateRadiologiRekanan;

public sealed record UpdateRadiologiRekananCommand(MRadiologiRekanan Data) : ICommand<UpdateRadiologiRekananResponse>;
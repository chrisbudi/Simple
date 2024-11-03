using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.CreateRadiologiRekanan;

public sealed record CreateRadiologiRekananCommand(MRadiologiRekanan Data) : ICommand<CreateRadiologiRekananResponse>;
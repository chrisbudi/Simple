using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.RadiologiRekanan.DeleteRadiologiRekanan;

public sealed record DeleteRadiologiRekananCommand(int Id) : ICommand<DeleteRadiologiRekananResponse>;
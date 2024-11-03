using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.CreateRekanan;

public sealed record CreateRekananCommand(MRekanan Data) : ICommand<CreateRekananResponse>;
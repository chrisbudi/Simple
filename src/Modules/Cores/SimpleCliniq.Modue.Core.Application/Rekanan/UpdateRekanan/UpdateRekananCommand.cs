using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Rekanan.UpdateRekanan;

public sealed record UpdateRekananCommand(MRekanan Data) : ICommand<UpdateRekananResponse>;
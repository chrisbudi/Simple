using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.CreateRuang;

public sealed record CreateRuangCommand(MRuang Data) : ICommand<CreateRuangResponse>;
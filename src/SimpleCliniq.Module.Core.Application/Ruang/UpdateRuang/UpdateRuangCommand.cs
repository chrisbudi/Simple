using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Ruang.UpdateRuang;

public sealed record UpdateRuangCommand(MRuang Data) : ICommand<UpdateRuangResponse>;
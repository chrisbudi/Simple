using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.CreateTindakan;

public sealed record CreateTindakanCommand(MTindakan Data) : ICommand<CreateTindakanResponse>;
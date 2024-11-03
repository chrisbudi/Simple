using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.Tindakan.UpdateTindakan;

public sealed record UpdateTindakanCommand(MTindakan Data) : ICommand<UpdateTindakanResponse>;
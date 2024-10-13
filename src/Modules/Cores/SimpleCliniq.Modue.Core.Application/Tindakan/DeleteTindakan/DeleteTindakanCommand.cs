using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Tindakan.DeleteTindakan;

public sealed record DeleteTindakanCommand(int Id) : ICommand<DeleteTindakanResponse>;
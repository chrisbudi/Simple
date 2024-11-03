using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Tindakan.GetTindakan;

public sealed record GetTindakanQuery(int Id) : IQuery<GetTindakanResponse>;
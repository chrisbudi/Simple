using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Ruang.GetRuang;

public sealed record GetRuangQuery(int Id) : IQuery<GetRuangResponse>;
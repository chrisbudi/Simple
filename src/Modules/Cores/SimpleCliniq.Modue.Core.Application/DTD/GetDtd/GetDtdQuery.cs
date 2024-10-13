using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DTD.GetDtd;

public sealed record GetDtdQuery(int Id) : IQuery<GetDtdResponse>;
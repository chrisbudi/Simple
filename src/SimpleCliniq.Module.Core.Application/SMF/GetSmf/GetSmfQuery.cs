using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.SMF.GetSmf;

public sealed record GetSmfQuery(int Id) : IQuery<GetSmfResponse>;
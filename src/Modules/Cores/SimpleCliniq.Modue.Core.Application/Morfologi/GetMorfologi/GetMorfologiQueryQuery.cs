using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Morfologi.GetMorfologi;

public sealed record GetMorfologiQuery(int Id) : IQuery<GetMorfologiResponse>;
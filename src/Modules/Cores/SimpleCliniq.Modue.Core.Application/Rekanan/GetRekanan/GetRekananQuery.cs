using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Rekanan.GetRekanan;

public sealed record GetRekananQuery(int Id) : IQuery<GetRekananResponse>;
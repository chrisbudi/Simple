using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.Diagnosa.GetDiagnosa;

public sealed record GetDiagnosaQuery(
    int Id
) : IQuery<GetDiagnosaResponse>;
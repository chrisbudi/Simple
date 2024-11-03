using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;

public sealed record GetAllDiagnosaMatrixQuery(
    int Page,
    int Size,
    long? SearchIdRuangan = 0,
    string Order = "",
    bool OrderAsc = true
) : IQuery<GetAllDiagnosaMatrixResponse>;
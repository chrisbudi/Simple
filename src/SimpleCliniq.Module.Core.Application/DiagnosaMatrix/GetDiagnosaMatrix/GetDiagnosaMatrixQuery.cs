using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.DiagnosaMatrix.GetDiagnosaMatrix;

public sealed record GetDiagnosaMatrixQuery(
    int Id
) : IQuery<GetDiagnosaMatrixResponse>;
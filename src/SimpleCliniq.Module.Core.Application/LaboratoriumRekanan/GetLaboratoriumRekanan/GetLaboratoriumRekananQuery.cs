using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.GetLaboratoriumRekanan;

public sealed record GetLaboratoriumRekananQuery(int Id) : IQuery<GetLaboratoriumRekananResponse>;
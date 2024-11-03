using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.GetLaboratoriumHarga;

public sealed record GetLaboratoriumHargaQuery(int Id) : IQuery<GetLaboratoriumHargaResponse>;
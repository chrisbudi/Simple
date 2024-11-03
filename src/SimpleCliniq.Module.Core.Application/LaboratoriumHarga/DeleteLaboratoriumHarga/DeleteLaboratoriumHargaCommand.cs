using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.DeleteLaboratoriumHarga;

public sealed record DeleteLaboratoriumHargaCommand(int Id) : ICommand<DeleteLaboratoriumHargaResponse>;
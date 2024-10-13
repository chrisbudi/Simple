using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.UpdateLaboratoriumHarga;

public sealed record UpdateLaboratoriumHargaCommand(MLaboratoriumHarga Data) : ICommand<UpdateLaboratoriumHargaResponse>;
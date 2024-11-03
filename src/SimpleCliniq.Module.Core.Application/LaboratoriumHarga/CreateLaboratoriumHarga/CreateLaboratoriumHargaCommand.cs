using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumHarga.CreateLaboratoriumHarga;

public sealed record CreateLaboratoriumHargaCommand(MLaboratoriumHarga Data) : ICommand<CreateLaboratoriumHargaResponse>;
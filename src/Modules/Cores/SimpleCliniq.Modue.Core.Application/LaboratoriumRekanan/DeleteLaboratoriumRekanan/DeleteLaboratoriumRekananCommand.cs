using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.DeleteLaboratoriumRekanan;

public sealed record DeleteLaboratoriumRekananCommand(int Id) : ICommand<DeleteLaboratoriumRekananResponse>;
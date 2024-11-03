using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.CreateLaboratoriumRekanan;

public sealed record CreateLaboratoriumRekananCommand(MLaboratoriumRekanan Data) : ICommand<CreateLaboratoriumRekananResponse>;
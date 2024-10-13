using Simple.Common.Application.Messaging;
using SimpleCliniq.Module.Core.Domain.Models;

namespace SimpleCliniq.Module.Core.Application.LaboratoriumRekanan.UpdateLaboratoriumRekanan;

public sealed record UpdateLaboratoriumRekananCommand(MLaboratoriumRekanan Data) : ICommand<UpdateLaboratoriumRekananResponse>;
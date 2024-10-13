namespace SimpleCliniq.Module.Core.Domain.Dtos;

public record GetAllResult<T>(List<T> Result, int Count);

namespace Backend.Shared.Infrastructure.Exceptions;

public class DuplicateEntityException(string message) : Exception(message);

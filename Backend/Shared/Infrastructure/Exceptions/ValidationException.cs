namespace Backend.Shared.Infrastructure.Exceptions;

public class ValidationException(string message) : Exception(message);

namespace Backend.Domain.Exceptions;

public class ImproperlyConfiguredException(string message) : Exception(message);
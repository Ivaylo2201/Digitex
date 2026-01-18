namespace Backend.Domain.Exceptions;

public class ImproperlyConfiguredException(string identifier) 
    : Exception($"{identifier} is not properly configured.");
namespace Backend.Domain.Common;

public record ConversionResult<T>(T Entity, decimal ConvertedPrice);
namespace Backend.Domain.Common;

public record FilterBase(List<string> Brands, Range<double> Price);
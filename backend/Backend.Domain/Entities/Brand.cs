namespace Backend.Domain.Entities;

public class Brand
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public ICollection<ProductBase> Products { get; init; } = [];
}
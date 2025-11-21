namespace Backend.Domain.Entities;

public class Sale
{
    public int Id { get; init; }
    public Guid ProductId { get; init; }
    public ProductBase Product { get; init; } = null!;
    public required int QuantitySold { get; init; }
    public DateTime SaleDate { get; init; } = DateTime.UtcNow;
}
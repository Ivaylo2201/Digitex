namespace Backend.Domain.Entities;

public class DiscountCoupon
{
    public int Id { get; init; }
    public required string Code { get; init; }
    public required int DiscountPercentage { get; init; }
    public int OrderId { get; init; }
    public Order Order { get; init; } = null!;
}
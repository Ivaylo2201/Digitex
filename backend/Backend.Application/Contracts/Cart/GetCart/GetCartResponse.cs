namespace Backend.Application.Contracts.Cart.GetCart;

public record GetCartResponse
{
    public required IReadOnlyList<ItemProjection> Items { get; init; }
    public required decimal TotalPrice { get; init; }
}
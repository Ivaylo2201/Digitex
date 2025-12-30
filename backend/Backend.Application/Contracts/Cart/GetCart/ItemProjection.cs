namespace Backend.Application.Contracts.Cart.GetCart;

public record ItemProjection
{
    public required int Id { get; init; }
    public required ProductProjection Product { get; init; }
    public required int Quantity { get; init; }
    public required decimal LineTotal { get; init; }
}
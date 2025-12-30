namespace Backend.Application.Contracts.Cart.AddToCart;

public record AddToCartRequest
{
    public required Guid ProductId { get; init; }
    public required int Quantity { get; init; }
    public int UserId { get; set; }
}

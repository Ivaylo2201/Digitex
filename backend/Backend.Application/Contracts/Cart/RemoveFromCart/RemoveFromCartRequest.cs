namespace Backend.Application.Contracts.Cart.RemoveFromCart;

public record RemoveFromCartRequest
{
    public int UserId { get; set; }
    public required int ItemId { get; init; }
}
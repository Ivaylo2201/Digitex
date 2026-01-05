namespace Backend.Application.Contracts.Cart.UpdateItemQuantity;

public record UpdateItemQuantityRequest
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public required int NewQuantity { get; init; }
}
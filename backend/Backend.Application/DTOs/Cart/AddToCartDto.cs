namespace Backend.Application.DTOs.Cart;

public record AddToCartDto
{
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
    public int? UserId { get; set; }  
}
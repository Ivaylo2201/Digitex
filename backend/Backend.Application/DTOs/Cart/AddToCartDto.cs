namespace Backend.Application.DTOs.Cart;

public record AddToCartDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }  
}
namespace Backend.Application.DTOs.Cart;

public record RemoveFromCartDto
{
    public required int UserId { get; set; }
    public required int ItemId { get; init; } 
}
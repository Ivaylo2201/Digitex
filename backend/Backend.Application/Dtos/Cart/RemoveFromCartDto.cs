namespace Backend.Application.Dtos.Cart;

public record RemoveFromCartDto
{
    public required int UserId { get; set; }
    public required int ItemId { get; init; } 
}
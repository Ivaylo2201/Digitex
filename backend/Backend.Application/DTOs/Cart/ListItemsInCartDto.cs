namespace Backend.Application.DTOs.Cart;

public record ListItemsInCartDto
{
    public required int UserId { get; set; }
}
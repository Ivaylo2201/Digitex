namespace Backend.Application.Dtos.Cart;

public record ListItemsInCartDto
{
    public required int UserId { get; set; }
}
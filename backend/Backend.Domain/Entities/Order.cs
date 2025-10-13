namespace Backend.Domain.Entities;

public class Order
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public int ShippingId { get; init; }
    public Shipping Shipping { get; init; } = null!;
    public ICollection<Item> Items { get; init; } = [];
}
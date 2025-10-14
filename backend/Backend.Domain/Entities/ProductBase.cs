namespace Backend.Domain.Entities;

public abstract class ProductBase
{
    public Guid Id { get; init; }
    public int BrandId { get; init; }
    public Brand Brand { get; init; } = null!;
    public required string Model { get; init; }
    public required string ImagePath { get; init; }
    public required double InitialPrice { get; init; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
    
    public ICollection<Item> Items { get; init; } = [];
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<User> LikedBy { get; init; } = [];

    public double Price => InitialPrice * (1 - DiscountPercentage / 100.0);
    public bool IsOutOfStock => Quantity == 0;
}
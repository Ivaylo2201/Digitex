namespace Backend.Domain.Entities;

public abstract class ProductBase
{
    public Guid Id { get; init; }
    public string Sku { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public int BrandId { get; init; }
    public Brand Brand { get; init; } = null!;
    public required string ModelName { get; init; }
    public required string ImagePath { get; init; }
    public required double InitialPrice { get; init; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
    public int Rating { get; set; }
    
    public ICollection<Item> Items { get; init; } = [];
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<User> LikedBy { get; init; } = [];
    public ICollection<ProductBase> Suggestions { get; init; } = [];
    public ICollection<ProductBase> SuggestedBy { get; init; } = [];
    public ICollection<Sale> Sales { get; init; } = [];  

    public double Price => InitialPrice * (1 - DiscountPercentage / 100.0);
    public bool IsInStock => Quantity is not 0;
}
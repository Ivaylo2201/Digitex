namespace Backend.Domain.Entities;

public abstract class ProductBase
{
    public Guid Id { get; set; }
    public string Sku { get; init; } = Guid.NewGuid().ToString("N")[..8];
    public int BrandId { get; set; }
    public Brand Brand { get; init; } = null!;
    public required string ModelName { get; set; }
    public string? ImagePath { get; set; }
    public required decimal InitialPrice { get; set; }
    public int DiscountPercentage { get; set; }
    public required int Quantity { get; set; }
    public int Rating { get; set; }
    
    public ICollection<Item> Items { get; init; } = [];
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<User> LikedBy { get; init; } = [];
    public ICollection<ProductBase> Suggestions { get; init; } = [];
    public ICollection<ProductBase> SuggestedBy { get; init; } = [];
    public ICollection<Sale> Sales { get; init; } = [];  

    public decimal Price => InitialPrice * (1 - DiscountPercentage / 100m);
    public double AverageRating => Reviews.Count is not 0 ? Reviews.Average(r => r.Rating) : 0;
    public string Category => GetType() switch { var product when product == typeof(GraphicsCard) => "graphics-cards", var product when product == typeof(Monitor) => "monitors", var product when product == typeof(Motherboard) => "motherboards", var product when product == typeof(PowerSupply) => "power-supplies", var product when product == typeof(Processor) => "processors", var product when product == typeof(Ram) => "rams", var product when product == typeof(Ssd) => "ssds", _ => throw new NotSupportedException("Invalid subfolder mapping.") };
}
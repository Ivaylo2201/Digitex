namespace Backend.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Username { get; init; }
    public required string Password { get; set; }
    public required string Email { get; init; }
    public bool IsVerified { get; set; }
    public Cart Cart { get; init; } = null!;
    
    public ICollection<Order> Orders { get; init; } = [];
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<ProductBase> LikedProducts { get; init; } = [];
    public ICollection<Address> Addresses { get; init; } = [];   
}
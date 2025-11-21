using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class User
{
    public int Id { get; init; }
    public Role Role { get; init; } = Role.Client;
    public required string Username { get; init; }
    public required string Password { get; set; }
    public required string Email { get; init; }
    public bool IsVerified { get; set; }
    public Cart Cart { get; init; } = null!;
    
    public ICollection<Order> Orders { get; init; } = [];
    public ICollection<Review> Reviews { get; init; } = [];
    public ICollection<ProductBase> Wishlist { get; init; } = [];
    public ICollection<Address> Addresses { get; init; } = [];   
}
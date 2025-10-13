using System.Reflection;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Cpu> Cpus => Set<Cpu>();
    public DbSet<Gpu> Gpus => Set<Gpu>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Monitor> Monitors => Set<Monitor>();
    public DbSet<Motherboard> Motherboards => Set<Motherboard>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<PowerSupply> PowerSupplies => Set<PowerSupply>();
    public DbSet<ProductBase> Products => Set<ProductBase>();
    public DbSet<Ram> Rams => Set<Ram>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Shipping> Shippings => Set<Shipping>();
    public DbSet<Storage> Storages => Set<Storage>();
    public DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
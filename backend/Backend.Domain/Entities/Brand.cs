﻿namespace Backend.Domain.Entities;

public class Brand
{
    public int Id { get; init; }
    public required string BrandName { get; init; }
    public ICollection<ProductBase> Products { get; init; } = [];
}
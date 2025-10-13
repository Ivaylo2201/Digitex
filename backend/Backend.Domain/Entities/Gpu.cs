﻿using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Gpu : ProductBase
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}
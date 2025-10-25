﻿using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Gpu;

public record GpuDto : ProductDto
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required BusWidth BusWidth { get; init; }
    public required int CudaCores { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}
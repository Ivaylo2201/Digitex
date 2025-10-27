﻿using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Cpu;

using Cpu = Backend.Domain.Entities.Cpu;
using Review = Backend.Domain.Entities.Review;

public class CpuDto(Cpu gpu) : ProductLongDto(gpu)
{
    public required int Cores { get; init; }
    public required int Threads { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required Socket Socket { get; init; } 
    public required int Tdp { get; init; }
}
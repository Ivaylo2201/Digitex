using Backend.Application.DTOs.Gpu;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class GpuExtensions
{
    public static GpuDto ToGpuDto(this Gpu gpu) => new(gpu)
    {
        Memory = gpu.Memory,
        ClockSpeed = gpu.ClockSpeed,
        BusWidth = gpu.BusWidth,
        CudaCores = gpu.CudaCores,
        DirectXSupport = gpu.DirectXSupport,
        Tdp = gpu.Tdp
    };
}
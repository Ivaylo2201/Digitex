using Backend.Application.DTOs.Cpu;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class CpuExtensions
{
    public static CpuDto ToCpuDto(this Cpu cpu) => new(cpu)
    {
        Cores = cpu.Cores,
        Threads = cpu.Threads,
        ClockSpeed = cpu.ClockSpeed,
        Socket = cpu.Socket,
        Tdp = cpu.Tdp
    };
}
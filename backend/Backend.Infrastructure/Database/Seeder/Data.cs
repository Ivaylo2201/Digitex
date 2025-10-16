using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database;

internal static class Data
{
    internal static readonly Dictionary<string, Brand> Brands = new()
    {
        ["intel"] = new Brand { Name = "Intel" },
        ["amd"] = new Brand { Name = "AMD" },
        ["arm"] = new Brand { Name = "ARM" },
        ["apple"] = new Brand { Name = "Apple" },
        ["nvidia"] = new Brand { Name = "Nvidia" },
        ["gigabyte"] = new Brand { Name = "GIGABYTE" },
        ["asus"] = new Brand { Name = "ASUS" },
        ["corsair"] = new Brand { Name = "Corsair" },
        ["gskill"] = new Brand { Name = "G.SKILL" },
        ["kingston"] = new Brand { Name = "Kingston" },
        ["crucial"] = new Brand { Name = "Crucial" },
        ["adata"] = new Brand { Name = "ADATA" },
        ["cooler master"] = new Brand { Name = "Cooler Master" },
        ["be quiet!"] = new Brand { Name = "be quiet!" },
        ["acer"] = new Brand { Name = "Acer" },
        ["lg"] = new Brand { Name = "LG" },
        ["samsung"] = new Brand { Name = "Samsung" },
        ["dell"] = new Brand { Name = "Dell" },
        ["asrock"] = new Brand { Name = "ASRock" },
        ["msi"] = new Brand { Name = "MSI" },
        ["benq"] = new Brand { Name = "BenQ" },
        ["t-force"] = new Brand { Name = "T-Force" },
        ["viper"] = new Brand { Name = "Viper" },
        ["western-digital"] = new Brand { Name = "Western Digital" },
        ["seagate"] = new Brand { Name = "Seagate" },
        ["toshiba"] = new Brand { Name = "Toshiba" },
        ["evga"] = new Brand { Name = "EVGA" },
        ["seasonic"] = new Brand { Name = "Seasonic" },
        ["thermaltake"] = new Brand { Name = "Thermaltake" }
    };
    internal static readonly List<Gpu> Gpus =
    [
        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 5060 Ti",
            ImagePath = "nvidia-rtx-5060-ti.jpg",
            InitialPrice = 500,
            DiscountPercentage = 15,
            Quantity = 10,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz3500),
            ClockSpeed = new ClockSpeed(Base: 2.41, Boost: 2.57),
            DirectXSupport = 12,
            Tdp = 180
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 4060 Ti",
            ImagePath = "nvidia-rtx-4060-ti.jpg",
            InitialPrice = 400,
            DiscountPercentage = 10,
            Quantity = 15,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2800),
            ClockSpeed = new ClockSpeed(Base: 2.46, Boost: 2.61),
            DirectXSupport = 12,
            Tdp = 160
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7600",
            ImagePath = "amd-radeon-rx-7600.jpg",
            InitialPrice = 270,
            DiscountPercentage = 5,
            Quantity = 20,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2000),
            ClockSpeed = new ClockSpeed(Base: 2.55, Boost: 2.76),
            DirectXSupport = 12,
            Tdp = 165
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7700 XT",
            ImagePath = "amd-radeon-rx-7700-xt.jpg",
            InitialPrice = 400,
            DiscountPercentage = 12,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 12, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2000),
            ClockSpeed = new ClockSpeed(Base: 2.58, Boost: 2.84),
            DirectXSupport = 12,
            Tdp = 245
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 4070 Ti",
            ImagePath = "nvidia-rtx-4070-ti.jpg",
            InitialPrice = 800,
            DiscountPercentage = 8,
            Quantity = 12,
            Memory = new Memory(CapacityInGb: 12, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2700),
            ClockSpeed = new ClockSpeed(Base: 2.61, Boost: 2.76),
            DirectXSupport = 12,
            Tdp = 285
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 4080",
            ImagePath = "nvidia-rtx-4080.jpg",
            InitialPrice = 1200,
            DiscountPercentage = 5,
            Quantity = 8,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz3200),
            ClockSpeed = new ClockSpeed(Base: 2.52, Boost: 2.61),
            DirectXSupport = 12,
            Tdp = 320
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 4090",
            ImagePath = "nvidia-rtx-4090.jpg",
            InitialPrice = 2000,
            DiscountPercentage = 3,
            Quantity = 5,
            Memory = new Memory(CapacityInGb: 24, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz3250),
            ClockSpeed = new ClockSpeed(Base: 2.52, Boost: 2.52),
            DirectXSupport = 12,
            Tdp = 450
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7800 XT",
            ImagePath = "amd-radeon-rx-7800-xt.jpg",
            InitialPrice = 650,
            DiscountPercentage = 10,
            Quantity = 10,
            Memory = new Memory(CapacityInGb: 16, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2200),
            ClockSpeed = new ClockSpeed(Base: 2.60, Boost: 2.80),
            DirectXSupport = 12,
            Tdp = 300
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7900 XTX",
            ImagePath = "amd-radeon-rx-7900-xtx.jpg",
            InitialPrice = 1000,
            DiscountPercentage = 7,
            Quantity = 6,
            Memory = new Memory(CapacityInGb: 24, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2500),
            ClockSpeed = new ClockSpeed(Base: 2.50, Boost: 2.60),
            DirectXSupport = 12,
            Tdp = 350
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 5070",
            ImagePath = "nvidia-rtx-5070.jpg",
            InitialPrice = 550,
            DiscountPercentage = 6,
            Quantity = 14,
            Memory = new Memory(CapacityInGb: 12, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2700),
            ClockSpeed = new ClockSpeed(Base: 2.50, Boost: 2.60),
            DirectXSupport = 12,
            Tdp = 220
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 5070 Ti",
            ImagePath = "nvidia-rtx-5070-ti.jpg",
            InitialPrice = 650,
            DiscountPercentage = 5,
            Quantity = 10,
            Memory = new Memory(CapacityInGb: 12, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2800),
            ClockSpeed = new ClockSpeed(Base: 2.55, Boost: 2.65),
            DirectXSupport = 12,
            Tdp = 230
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7600 XT",
            ImagePath = "amd-radeon-rx-7600-xt.jpg",
            InitialPrice = 320,
            DiscountPercentage = 8,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2000),
            ClockSpeed = new ClockSpeed(Base: 2.60, Boost: 2.70),
            DirectXSupport = 12,
            Tdp = 170
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "RTX 4060",
            ImagePath = "nvidia-rtx-4060.jpg",
            InitialPrice = 350,
            DiscountPercentage = 4,
            Quantity = 20,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2400),
            ClockSpeed = new ClockSpeed(Base: 2.40, Boost: 2.50),
            DirectXSupport = 12,
            Tdp = 130
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 7500 XT",
            ImagePath = "amd-radeon-rx-7500-xt.jpg",
            InitialPrice = 250,
            DiscountPercentage = 7,
            Quantity = 22,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz1800),
            ClockSpeed = new ClockSpeed(Base: 2.40, Boost: 2.50),
            DirectXSupport = 12,
            Tdp = 150
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 1660 Ti",
            ImagePath = "nvidia-gtx-1660-ti.jpg",
            InitialPrice = 200,
            DiscountPercentage = 10,
            Quantity = 25,
            Memory = new Memory(CapacityInGb: 6, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2000),
            ClockSpeed = new ClockSpeed(Base: 1.50, Boost: 1.70),
            DirectXSupport = 12,
            Tdp = 120
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 1080 Ti",
            ImagePath = "nvidia-gtx-1080-ti.jpg",
            InitialPrice = 450,
            DiscountPercentage = 10,
            Quantity = 8,
            Memory = new Memory(CapacityInGb: 11, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz3466),
            ClockSpeed = new ClockSpeed(Base: 1.48, Boost: 1.58),
            DirectXSupport = 12,
            Tdp = 250
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 1070",
            ImagePath = "nvidia-gtx-1070.jpg",
            InitialPrice = 350,
            DiscountPercentage = 8,
            Quantity = 12,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz3000),
            ClockSpeed = new ClockSpeed(Base: 1.5, Boost: 1.68),
            DirectXSupport = 12,
            Tdp = 150
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 580",
            ImagePath = "amd-radeon-rx-580.jpg",
            InitialPrice = 200,
            DiscountPercentage = 7,
            Quantity = 20,
            Memory = new Memory(CapacityInGb: 8, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz3333),
            ClockSpeed = new ClockSpeed(Base: 1.25, Boost: 1.34),
            DirectXSupport = 12,
            Tdp = 185
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 570",
            ImagePath = "amd-radeon-rx-570.jpg",
            InitialPrice = 150,
            DiscountPercentage = 5,
            Quantity = 25,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2933),
            ClockSpeed = new ClockSpeed(Base: 1.15, Boost: 1.24),
            DirectXSupport = 12,
            Tdp = 150
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 1060 6GB",
            ImagePath = "nvidia-gtx-1060-6gb.jpg",
            InitialPrice = 220,
            DiscountPercentage = 6,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 6, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz3200),
            ClockSpeed = new ClockSpeed(Base: 1.5, Boost: 1.7),
            DirectXSupport = 12,
            Tdp = 120
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Arc A380",
            ImagePath = "intel-arc-a380.jpg",
            InitialPrice = 150,
            DiscountPercentage = 5,
            Quantity = 15,
            Memory = new Memory(CapacityInGb: 6, Type: MemoryType.GDdr6X, Frequency: Frequency.Mhz2500),
            ClockSpeed = new ClockSpeed(Base: 1.0, Boost: 2.0),
            DirectXSupport = 12,
            Tdp = 75
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 1050 Ti",
            ImagePath = "nvidia-gtx-1050-ti.jpg",
            InitialPrice = 130,
            DiscountPercentage = 5,
            Quantity = 22,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2700),
            ClockSpeed = new ClockSpeed(Base: 1.3, Boost: 1.45),
            DirectXSupport = 12,
            Tdp = 75
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 560",
            ImagePath = "amd-radeon-rx-560.jpg",
            InitialPrice = 100,
            DiscountPercentage = 5,
            Quantity = 30,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2800),
            ClockSpeed = new ClockSpeed(Base: 1.175, Boost: 1.25),
            DirectXSupport = 12,
            Tdp = 80
        },

        new()
        {
            Brand = Brands["nvidia"],
            Model = "GTX 970",
            ImagePath = "nvidia-gtx-970.jpg",
            InitialPrice = 180,
            DiscountPercentage = 6,
            Quantity = 12,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2200),
            ClockSpeed = new ClockSpeed(Base: 1.05, Boost: 1.17),
            DirectXSupport = 12,
            Tdp = 145
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Radeon RX 470",
            ImagePath = "amd-radeon-rx-470.jpg",
            InitialPrice = 120,
            DiscountPercentage = 5,
            Quantity = 18,
            Memory = new Memory(CapacityInGb: 4, Type: MemoryType.GDdr5X, Frequency: Frequency.Mhz2133),
            ClockSpeed = new ClockSpeed(Base: 0.926, Boost: 1.2),
            DirectXSupport = 12,
            Tdp = 120
        }
    ];
    internal static readonly List<Cpu> Cpus =
    [
        new()
        {
            Brand = Brands["intel"],
            Model = "Core i9-14900K",
            ImagePath = "intel-i9-14900k.jpg",
            InitialPrice = 599,
            DiscountPercentage = 5,
            Quantity = 8,
            Cores = 24,
            Threads = 32,
            ClockSpeed = new ClockSpeed(Base: 3.2, Boost: 6.0),
            Socket = Socket.Lga1700,
            Tdp = 125
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i7-14700K",
            ImagePath = "intel-i7-14700k.jpg",
            InitialPrice = 399,
            DiscountPercentage = 6,
            Quantity = 10,
            Cores = 20,
            Threads = 28,
            ClockSpeed = new ClockSpeed(Base: 3.4, Boost: 5.6),
            Socket = Socket.Lga1700,
            Tdp = 125
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i5-14600K",
            ImagePath = "intel-i5-14600k.jpg",
            InitialPrice = 299,
            DiscountPercentage = 5,
            Quantity = 15,
            Cores = 14,
            Threads = 20,
            ClockSpeed = new ClockSpeed(Base: 3.5, Boost: 5.3),
            Socket = Socket.Lga1700,
            Tdp = 125
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 9 7950XT",
            ImagePath = "amd-ryzen-9-7950xt.jpg",
            InitialPrice = 629,
            DiscountPercentage = 6,
            Quantity = 9,
            Cores = 16,
            Threads = 32,
            ClockSpeed = new ClockSpeed(Base: 4.6, Boost: 5.8),
            Socket = Socket.Am5,
            Tdp = 170
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 9 7900XT",
            ImagePath = "amd-ryzen-9-7900xt.jpg",
            InitialPrice = 469,
            DiscountPercentage = 8,
            Quantity = 12,
            Cores = 12,
            Threads = 24,
            ClockSpeed = new ClockSpeed(Base: 4.8, Boost: 5.7),
            Socket = Socket.Am5,
            Tdp = 170
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i9-15000K",
            ImagePath = "intel-i9-15000k.jpg",
            InitialPrice = 619,
            DiscountPercentage = 5,
            Quantity = 8,
            Cores = 26,
            Threads = 34,
            ClockSpeed = new ClockSpeed(Base: 3.3, Boost: 6.1),
            Socket = Socket.Lga1700,
            Tdp = 130
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i7-14800K",
            ImagePath = "intel-i7-14800k.jpg",
            InitialPrice = 419,
            DiscountPercentage = 6,
            Quantity = 10,
            Cores = 22,
            Threads = 30,
            ClockSpeed = new ClockSpeed(Base: 3.5, Boost: 5.7),
            Socket = Socket.Lga1700,
            Tdp = 130
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i5-14600KF",
            ImagePath = "intel-i5-14600kf.jpg",
            InitialPrice = 309,
            DiscountPercentage = 5,
            Quantity = 15,
            Cores = 14,
            Threads = 20,
            ClockSpeed = new ClockSpeed(Base: 3.6, Boost: 5.3),
            Socket = Socket.Lga1700,
            Tdp = 125
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 9 7950X",
            ImagePath = "amd-ryzen-9-7950x.jpg",
            InitialPrice = 599,
            DiscountPercentage = 7,
            Quantity = 9,
            Cores = 16,
            Threads = 32,
            ClockSpeed = new ClockSpeed(Base: 4.5, Boost: 5.7),
            Socket = Socket.Am5,
            Tdp = 170
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 9 7900X",
            ImagePath = "amd-ryzen-9-7900x.jpg",
            InitialPrice = 449,
            DiscountPercentage = 8,
            Quantity = 12,
            Cores = 12,
            Threads = 24,
            ClockSpeed = new ClockSpeed(Base: 4.7, Boost: 5.6),
            Socket = Socket.Am5,
            Tdp = 170
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i5-12400F",
            ImagePath = "intel-i5-12400f.jpg",
            InitialPrice = 179,
            DiscountPercentage = 10,
            Quantity = 20,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 2.5, Boost: 4.4),
            Socket = Socket.Lga1700,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i3-12100",
            ImagePath = "intel-i3-12100.jpg",
            InitialPrice = 129,
            DiscountPercentage = 12,
            Quantity = 25,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.3, Boost: 4.3),
            Socket = Socket.Lga1700,
            Tdp = 60
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 7 5800X",
            ImagePath = "amd-ryzen-7-5800x.jpg",
            InitialPrice = 249,
            DiscountPercentage = 10,
            Quantity = 18,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.8, Boost: 4.7),
            Socket = Socket.Am4,
            Tdp = 105
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 5 5600",
            ImagePath = "amd-ryzen-5-5600.jpg",
            InitialPrice = 149,
            DiscountPercentage = 10,
            Quantity = 22,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.5, Boost: 4.4),
            Socket = Socket.Am4,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 3 4100",
            ImagePath = "amd-ryzen-3-4100.jpg",
            InitialPrice = 99,
            DiscountPercentage = 15,
            Quantity = 30,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.8, Boost: 4.0),
            Socket = Socket.Am4,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i7-10700K",
            ImagePath = "intel-i7-10700k.jpg",
            InitialPrice = 299,
            DiscountPercentage = 8,
            Quantity = 15,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.8, Boost: 5.1),
            Socket = Socket.Lga1200,
            Tdp = 125
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i5-10400F",
            ImagePath = "intel-i5-10400f.jpg",
            InitialPrice = 149,
            DiscountPercentage = 10,
            Quantity = 25,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 2.9, Boost: 4.3),
            Socket = Socket.Lga1200,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i3-10100",
            ImagePath = "intel-i3-10100.jpg",
            InitialPrice = 109,
            DiscountPercentage = 12,
            Quantity = 28,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.6, Boost: 4.3),
            Socket = Socket.Lga1200,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 5 3600",
            ImagePath = "amd-ryzen-5-3600.jpg",
            InitialPrice = 129,
            DiscountPercentage = 10,
            Quantity = 26,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.6, Boost: 4.2),
            Socket = Socket.Am4,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 7 2700X",
            ImagePath = "amd-ryzen-7-2700x.jpg",
            InitialPrice = 169,
            DiscountPercentage = 12,
            Quantity = 20,
            Cores = 8,
            Threads = 16,
            ClockSpeed = new ClockSpeed(Base: 3.7, Boost: 4.3),
            Socket = Socket.Am4,
            Tdp = 105
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i5-9400F",
            ImagePath = "intel-i5-9400f.jpg",
            InitialPrice = 119,
            DiscountPercentage = 10,
            Quantity = 25,
            Cores = 6,
            Threads = 6,
            ClockSpeed = new ClockSpeed(Base: 2.9, Boost: 4.1),
            Socket = Socket.Lga1151,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i7-8700K",
            ImagePath = "intel-i7-8700k.jpg",
            InitialPrice = 189,
            DiscountPercentage = 9,
            Quantity = 18,
            Cores = 6,
            Threads = 12,
            ClockSpeed = new ClockSpeed(Base: 3.7, Boost: 4.7),
            Socket = Socket.Lga1151,
            Tdp = 95
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen 3 3100",
            ImagePath = "amd-ryzen-3-3100.jpg",
            InitialPrice = 99,
            DiscountPercentage = 10,
            Quantity = 30,
            Cores = 4,
            Threads = 8,
            ClockSpeed = new ClockSpeed(Base: 3.6, Boost: 3.9),
            Socket = Socket.Am4,
            Tdp = 65
        },

        new()
        {
            Brand = Brands["amd"],
            Model = "Ryzen Threadripper 3960X",
            ImagePath = "amd-threadripper-3960x.jpg",
            InitialPrice = 1199,
            DiscountPercentage = 5,
            Quantity = 4,
            Cores = 24,
            Threads = 48,
            ClockSpeed = new ClockSpeed(Base: 3.8, Boost: 4.5),
            Socket = Socket.STrx4,
            Tdp = 280
        },

        new()
        {
            Brand = Brands["intel"],
            Model = "Core i9-10980XE",
            ImagePath = "intel-i9-10980xe.jpg",
            InitialPrice = 979,
            DiscountPercentage = 7,
            Quantity = 5,
            Cores = 18,
            Threads = 36,
            ClockSpeed = new ClockSpeed(Base: 3.0, Boost: 4.8),
            Socket = Socket.Lga2066,
            Tdp = 165
        }
    ];
    internal static readonly List<Motherboard> Motherboards =
    [
        new()
        {
            Brand = Brands["asus"],
            Model = "ROG Strix Z790-E",
            ImagePath = "asus-rog-strix-z790-e.jpg",
            InitialPrice = 499,
            DiscountPercentage = 5,
            Quantity = 10,
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.Atx,
            Chipset = "Z790",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "MEG Z790 ACE",
            ImagePath = "msi-meg-z790-ace.jpg",
            InitialPrice = 549,
            DiscountPercentage = 6,
            Quantity = 8,
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.Atx,
            Chipset = "Z790",
            RamSlots = 4,
            PcieSlots = 4
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "AORUS B650 Elite",
            ImagePath = "gigabyte-aorus-b650-elite.jpg",
            InitialPrice = 269,
            DiscountPercentage = 5,
            Quantity = 12,
            Socket = Socket.Am5,
            FormFactor = FormFactor.Atx,
            Chipset = "B650",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "TUF Gaming B550-PLUS",
            ImagePath = "asus-tuf-gaming-b550-plus.jpg",
            InitialPrice = 179,
            DiscountPercentage = 8,
            Quantity = 15,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 2
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "MAG B660 Tomahawk",
            ImagePath = "msi-mag-b660-tomahawk.jpg",
            InitialPrice = 189,
            DiscountPercentage = 6,
            Quantity = 12,
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.Atx,
            Chipset = "B660",
            RamSlots = 4,
            PcieSlots = 2
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "X570 AORUS Elite",
            ImagePath = "gigabyte-x570-aorus-elite.jpg",
            InitialPrice = 219,
            DiscountPercentage = 7,
            Quantity = 10,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "X570",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "ROG Crosshair VIII Hero",
            ImagePath = "asus-rog-crosshair-viii-hero.jpg",
            InitialPrice = 399,
            DiscountPercentage = 5,
            Quantity = 7,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "X570",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "TRX40 Creator",
            ImagePath = "msi-trx40-creator.jpg",
            InitialPrice = 699,
            DiscountPercentage = 4,
            Quantity = 5,
            Socket = Socket.STrx4,
            FormFactor = FormFactor.EAtx,
            Chipset = "TRX40",
            RamSlots = 8,
            PcieSlots = 4
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "X399 AORUS Gaming 7",
            ImagePath = "gigabyte-x399-aorus-gaming-7.jpg",
            InitialPrice = 449,
            DiscountPercentage = 5,
            Quantity = 6,
            Socket = Socket.Tr4,
            FormFactor = FormFactor.Atx,
            Chipset = "X399",
            RamSlots = 8,
            PcieSlots = 4
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "ROG Strix B660-F Gaming WiFi",
            ImagePath = "asus-rog-strix-b660-f-gaming-wifi.jpg",
            InitialPrice = 239,
            DiscountPercentage = 6,
            Quantity = 14,
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.Atx,
            Chipset = "B660",
            RamSlots = 4,
            PcieSlots = 2
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "Prime B660M-A",
            ImagePath = "asus-prime-b660m-a.jpg",
            InitialPrice = 129,
            DiscountPercentage = 7,
            Quantity = 20,
            Socket = Socket.Lga1700,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B660",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "B550M Pro-VDH WiFi",
            ImagePath = "msi-b550m-pro-vdh-wifi.jpg",
            InitialPrice = 99,
            DiscountPercentage = 8,
            Quantity = 25,
            Socket = Socket.Am4,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "B460M DS3H",
            ImagePath = "gigabyte-b460m-ds3h.jpg",
            InitialPrice = 89,
            DiscountPercentage = 10,
            Quantity = 22,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B460",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "TUF B450-PLUS Gaming",
            ImagePath = "asus-tuf-b450-plus-gaming.jpg",
            InitialPrice = 99,
            DiscountPercentage = 9,
            Quantity = 18,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B450",
            RamSlots = 4,
            PcieSlots = 2
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "H510M PRO-VDH",
            ImagePath = "msi-h510m-pro-vdh.jpg",
            InitialPrice = 79,
            DiscountPercentage = 12,
            Quantity = 30,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "H510",
            RamSlots = 2,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "A320M-S2H",
            ImagePath = "gigabyte-a320m-s2h.jpg",
            InitialPrice = 59,
            DiscountPercentage = 15,
            Quantity = 35,
            Socket = Socket.Am4,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "A320",
            RamSlots = 2,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "Prime H510M-K",
            ImagePath = "asus-prime-h510m-k.jpg",
            InitialPrice = 69,
            DiscountPercentage = 10,
            Quantity = 28,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "H510",
            RamSlots = 2,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "B460M-A PRO",
            ImagePath = "msi-b460m-a-pro.jpg",
            InitialPrice = 94,
            DiscountPercentage = 8,
            Quantity = 24,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B460",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "B365M DS3H",
            ImagePath = "gigabyte-b365m-ds3h.jpg",
            InitialPrice = 79,
            DiscountPercentage = 10,
            Quantity = 26,
            Socket = Socket.Lga1151,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B365",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "PRIME B450M-A",
            ImagePath = "asus-prime-b450m-a.jpg",
            InitialPrice = 89,
            DiscountPercentage = 9,
            Quantity = 20,
            Socket = Socket.Am4,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B450",
            RamSlots = 4,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "ROG Strix B550-F Gaming",
            ImagePath = "asus-b550f.jpg",
            InitialPrice = 189,
            DiscountPercentage = 10,
            Quantity = 12,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "MAG B460M Mortar",
            ImagePath = "msi-b460m.jpg",
            InitialPrice = 99,
            DiscountPercentage = 8,
            Quantity = 15,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "B460",
            RamSlots = 4,
            PcieSlots = 2
        },

        new()
        {
            Brand = Brands["gigabyte"],
            Model = "B550 AORUS Elite",
            ImagePath = "gigabyte-b550.jpg",
            InitialPrice = 159,
            DiscountPercentage = 12,
            Quantity = 10,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B550",
            RamSlots = 4,
            PcieSlots = 3
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "Prime H510M-A",
            ImagePath = "asus-h510m.jpg",
            InitialPrice = 79,
            DiscountPercentage = 10,
            Quantity = 20,
            Socket = Socket.Lga1200,
            FormFactor = FormFactor.MicroAtx,
            Chipset = "H510",
            RamSlots = 2,
            PcieSlots = 1
        },

        new()
        {
            Brand = Brands["msi"],
            Model = "B450 Tomahawk Max",
            ImagePath = "msi-b450.jpg",
            InitialPrice = 99,
            DiscountPercentage = 7,
            Quantity = 14,
            Socket = Socket.Am4,
            FormFactor = FormFactor.Atx,
            Chipset = "B450",
            RamSlots = 4,
            PcieSlots = 3
        }
    ];
    internal static readonly List<Monitor> Monitors =
    [
        new()
        {
            Brand = Brands["asus"],
            Model = "VG248Q",
            ImagePath = "asus-vg248q.jpg",
            InitialPrice = 249,
            DiscountPercentage = 10,
            Quantity = 15,
            DisplayDiagonal = 24,
            RefreshRate = 165,
            Latency = 1,
            Matrix = Matrix.Tn,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["lg"],
            Model = "27GL850",
            ImagePath = "lg-27gl850.jpg",
            InitialPrice = 379,
            DiscountPercentage = 8,
            Quantity = 10,
            DisplayDiagonal = 27,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "Odyssey G7",
            ImagePath = "samsung-odyssey-g7.jpg",
            InitialPrice = 699,
            DiscountPercentage = 7,
            Quantity = 7,
            DisplayDiagonal = 32,
            RefreshRate = 240,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["acer"],
            Model = "Predator XB273K",
            ImagePath = "acer-predator-xb273k.jpg",
            InitialPrice = 899,
            DiscountPercentage = 5,
            Quantity = 5,
            DisplayDiagonal = 27,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3840, 2160),
            PixelSize = 0.155
        },

        new()
        {
            Brand = Brands["benq"],
            Model = "EX3501R",
            ImagePath = "benq-ex3501r.jpg",
            InitialPrice = 499,
            DiscountPercentage = 10,
            Quantity = 8,
            DisplayDiagonal = 35,
            RefreshRate = 100,
            Latency = 4,
            Matrix = Matrix.Va,
            Resolution = new Resolution(3440, 1440),
            PixelSize = 0.232
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "TUF Gaming VG27AQ",
            ImagePath = "asus-tuf-vg27aq.jpg",
            InitialPrice = 349,
            DiscountPercentage = 7,
            Quantity = 12,
            DisplayDiagonal = 27,
            RefreshRate = 165,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["lg"],
            Model = "34GP83A-B",
            ImagePath = "lg-34gp83a-b.jpg",
            InitialPrice = 799,
            DiscountPercentage = 6,
            Quantity = 6,
            DisplayDiagonal = 34,
            RefreshRate = 160,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3440, 1440),
            PixelSize = 0.232
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "Odyssey G5",
            ImagePath = "samsung-odyssey-g5.jpg",
            InitialPrice = 299,
            DiscountPercentage = 12,
            Quantity = 15,
            DisplayDiagonal = 27,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["acer"],
            Model = "Nitro XV272U",
            ImagePath = "acer-nitro-xv272u.jpg",
            InitialPrice = 329,
            DiscountPercentage = 8,
            Quantity = 10,
            DisplayDiagonal = 27,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["benq"],
            Model = "EX2780Q",
            ImagePath = "benq-ex2780q.jpg",
            InitialPrice = 379,
            DiscountPercentage = 10,
            Quantity = 9,
            DisplayDiagonal = 27,
            RefreshRate = 144,
            Latency = 2,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "VP228HE",
            ImagePath = "asus-vp228he.jpg",
            InitialPrice = 119,
            DiscountPercentage = 15,
            Quantity = 20,
            DisplayDiagonal = 21,
            RefreshRate = 60,
            Latency = 5,
            Matrix = Matrix.Tn,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.248
        },

        new()
        {
            Brand = Brands["lg"],
            Model = "24MP59G",
            ImagePath = "lg-24mp59g.jpg",
            InitialPrice = 159,
            DiscountPercentage = 12,
            Quantity = 18,
            DisplayDiagonal = 24,
            RefreshRate = 75,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["acer"],
            Model = "KG241Q",
            ImagePath = "acer-kg241q.jpg",
            InitialPrice = 139,
            DiscountPercentage = 10,
            Quantity = 22,
            DisplayDiagonal = 24,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Tn,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "Odyssey G3",
            ImagePath = "samsung-odyssey-g3.jpg",
            InitialPrice = 179,
            DiscountPercentage = 10,
            Quantity = 15,
            DisplayDiagonal = 24,
            RefreshRate = 144,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["benq"],
            Model = "GW2480",
            ImagePath = "benq-gw2480.jpg",
            InitialPrice = 129,
            DiscountPercentage = 12,
            Quantity = 18,
            DisplayDiagonal = 24,
            RefreshRate = 60,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "ROG Swift PG259QN",
            ImagePath = "asus-pg259qn.jpg",
            InitialPrice = 699,
            DiscountPercentage = 5,
            Quantity = 8,
            DisplayDiagonal = 24,
            RefreshRate = 360,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["lg"],
            Model = "27UL500",
            ImagePath = "lg-27ul500.jpg",
            InitialPrice = 329,
            DiscountPercentage = 8,
            Quantity = 10,
            DisplayDiagonal = 27,
            RefreshRate = 60,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3840, 2160),
            PixelSize = 0.155
        },

        new()
        {
            Brand = Brands["acer"],
            Model = "Nitro XV240Y",
            ImagePath = "acer-nitro-xv240y.jpg",
            InitialPrice = 179,
            DiscountPercentage = 12,
            Quantity = 12,
            DisplayDiagonal = 24,
            RefreshRate = 75,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "SR35",
            ImagePath = "samsung-sr35.jpg",
            InitialPrice = 149,
            DiscountPercentage = 10,
            Quantity = 14,
            DisplayDiagonal = 24,
            RefreshRate = 75,
            Latency = 5,
            Matrix = Matrix.Va,
            Resolution = new Resolution(1920, 1080),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["benq"],
            Model = "EX3203R",
            ImagePath = "benq-ex3203r.jpg",
            InitialPrice = 469,
            DiscountPercentage = 7,
            Quantity = 7,
            DisplayDiagonal = 32,
            RefreshRate = 144,
            Latency = 4,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["asus"],
            Model = "TUF Gaming VG32VQ",
            ImagePath = "asus-vg32vq.jpg",
            InitialPrice = 399,
            DiscountPercentage = 6,
            Quantity = 8,
            DisplayDiagonal = 32,
            RefreshRate = 165,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.276
        },

        new()
        {
            Brand = Brands["lg"],
            Model = "34WN80C",
            ImagePath = "lg-34wn80c.jpg",
            InitialPrice = 499,
            DiscountPercentage = 8,
            Quantity = 6,
            DisplayDiagonal = 34,
            RefreshRate = 75,
            Latency = 5,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3440, 1440),
            PixelSize = 0.232
        },

        new()
        {
            Brand = Brands["acer"],
            Model = "Predator X34",
            ImagePath = "acer-predator-x34.jpg",
            InitialPrice = 799,
            DiscountPercentage = 5,
            Quantity = 4,
            DisplayDiagonal = 34,
            RefreshRate = 120,
            Latency = 4,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(3440, 1440),
            PixelSize = 0.232
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "Odyssey G9",
            ImagePath = "samsung-odyssey-g9.jpg",
            InitialPrice = 1399,
            DiscountPercentage = 7,
            Quantity = 3,
            DisplayDiagonal = 49,
            RefreshRate = 240,
            Latency = 1,
            Matrix = Matrix.Va,
            Resolution = new Resolution(5120, 1440),
            PixelSize = 0.233
        },

        new()
        {
            Brand = Brands["benq"],
            Model = "EX2710Q",
            ImagePath = "benq-ex2710q.jpg",
            InitialPrice = 399,
            DiscountPercentage = 6,
            Quantity = 5,
            DisplayDiagonal = 27,
            RefreshRate = 165,
            Latency = 1,
            Matrix = Matrix.Ips,
            Resolution = new Resolution(2560, 1440),
            PixelSize = 0.233
        }
    ];
    internal static readonly List<Ram> Rams =
    [
        new()
        {
            Brand = Brands["corsair"],
            Model = "Vengeance LPX 8GB",
            ImagePath = "corsair-vengeance-lpx-8gb.jpg",
            InitialPrice = 39,
            DiscountPercentage = 10,
            Quantity = 30,
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18-36"
        },

        new()
        {
            Brand = Brands["gskill"],
            Model = "Ripjaws V 16GB",
            ImagePath = "gskill-ripjaws-v-16gb.jpg",
            InitialPrice = 79,
            DiscountPercentage = 8,
            Quantity = 25,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22-42"
        },

        new()
        {
            Brand = Brands["kingston"],
            Model = "HyperX Fury 8GB",
            ImagePath = "kingston-hyperx-fury-8gb.jpg",
            InitialPrice = 42,
            DiscountPercentage = 12,
            Quantity = 28,
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz2666),
            Timing = "15-17-17-35"
        },

        new()
        {
            Brand = Brands["t-force"],
            Model = "Delta RGB 16GB",
            ImagePath = "tforce-delta-16gb.jpg",
            InitialPrice = 89,
            DiscountPercentage = 7,
            Quantity = 20,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18-38"
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "Vengeance RGB Pro 32GB",
            ImagePath = "corsair-vengeance-rgb-pro-32gb.jpg",
            InitialPrice = 159,
            DiscountPercentage = 5,
            Quantity = 15,
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22-42"
        },

        new()
        {
            Brand = Brands["gskill"],
            Model = "Trident Z Neo 32GB",
            ImagePath = "gskill-trident-z-neo-32gb.jpg",
            InitialPrice = 169,
            DiscountPercentage = 6,
            Quantity = 12,
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "19-26-26-46"
        },

        new()
        {
            Brand = Brands["kingston"],
            Model = "HyperX Predator 16GB",
            ImagePath = "kingston-hyperx-predator-16gb.jpg",
            InitialPrice = 99,
            DiscountPercentage = 8,
            Quantity = 18,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-19-19-39"
        },

        new()
        {
            Brand = Brands["viper"],
            Model = "Steel 8GB",
            ImagePath = "viper-steel-8gb.jpg",
            InitialPrice = 37,
            DiscountPercentage = 10,
            Quantity = 35,
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz3000),
            Timing = "16-18-18-36"
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "Vengeance RGB Pro SL 16GB",
            ImagePath = "corsair-vengeance-rgb-pro-sl-16gb.jpg",
            InitialPrice = 95,
            DiscountPercentage = 7,
            Quantity = 20,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22-42"
        },

        new()
        {
            Brand = Brands["t-force"],
            Model = "Vulcan Z 8GB",
            ImagePath = "tforce-vulcan-8gb.jpg",
            InitialPrice = 34,
            DiscountPercentage = 12,
            Quantity = 40,
            Memory = new Memory(8, MemoryType.Ddr4, Frequency.Mhz3000),
            Timing = "16-18-18-36"
        },

        new()
        {
            Brand = Brands["gskill"],
            Model = "Ripjaws S5 16GB",
            ImagePath = "gskill-ripjaws-s5-16gb.jpg",
            InitialPrice = 89,
            DiscountPercentage = 6,
            Quantity = 22,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18-38"
        },

        new()
        {
            Brand = Brands["kingston"],
            Model = "Fury Beast 32GB",
            ImagePath = "kingston-fury-beast-32gb.jpg",
            InitialPrice = 175,
            DiscountPercentage = 5,
            Quantity = 12,
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "36-36-36-72"
        },

        new()
        {
            Brand = Brands["t-force"],
            Model = "Delta 32GB",
            ImagePath = "tforce-delta-32gb.jpg",
            InitialPrice = 155,
            DiscountPercentage = 6,
            Quantity = 10,
            Memory = new Memory(32, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18-38"
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "Vengeance LPX 16GB",
            ImagePath = "corsair-vengeance-lpx-16gb.jpg",
            InitialPrice = 75,
            DiscountPercentage = 8,
            Quantity = 25,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3200),
            Timing = "16-18-18-36"
        },

        new()
        {
            Brand = Brands["gskill"],
            Model = "Trident Z RGB 16GB",
            ImagePath = "gskill-trident-z-rgb-16gb.jpg",
            InitialPrice = 89,
            DiscountPercentage = 7,
            Quantity = 20,
            Memory = new Memory(16, MemoryType.Ddr4, Frequency.Mhz3600),
            Timing = "18-22-22-42"
        }
    ];
    internal static readonly List<Storage> Storages =
    [
        new()
        {
            Brand = Brands["samsung"],
            Model = "970 Evo Plus 500GB",
            ImagePath = "samsung-970-evo-plus-500gb.jpg",
            InitialPrice = 79,
            DiscountPercentage = 10,
            Quantity = 25,
            Memory = new Memory(500, MemoryType.Ddr4, Frequency.Mhz3600),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["western-digital"],
            Model = "Blue SN570 1TB",
            ImagePath = "western-digital-blue-sn570-1tb.jpg",
            InitialPrice = 99,
            DiscountPercentage = 8,
            Quantity = 20,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz3200),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["crucial"],
            Model = "P3 500GB",
            ImagePath = "crucial-p3-500gb.jpg",
            InitialPrice = 65,
            DiscountPercentage = 12,
            Quantity = 30,
            Memory = new Memory(500, MemoryType.Ddr4, Frequency.Mhz3000),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "980 Pro 1TB",
            ImagePath = "samsung-980-pro-1tb.jpg",
            InitialPrice = 149,
            DiscountPercentage = 7,
            Quantity = 15,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz3600),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["western-digital"],
            Model = "Black SN850 2TB",
            ImagePath = "western-digital-black-sn850-2tb.jpg",
            InitialPrice = 299,
            DiscountPercentage = 5,
            Quantity = 10,
            Memory = new Memory(2000, MemoryType.Ddr4, Frequency.Mhz3600),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["seagate"],
            Model = "Barracuda 2TB",
            ImagePath = "seagate-barracuda-2tb.jpg",
            InitialPrice = 59,
            DiscountPercentage = 10,
            Quantity = 40,
            Memory = new Memory(2000, MemoryType.Ddr4, Frequency.Mhz2500),
            Type = StorageType.Hdd
        },

        new()
        {
            Brand = Brands["western-digital"],
            Model = "Blue 1TB",
            ImagePath = "western-digital-blue-1tb.jpg",
            InitialPrice = 49,
            DiscountPercentage = 12,
            Quantity = 35,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz2400),
            Type = StorageType.Hdd
        },

        new()
        {
            Brand = Brands["seagate"],
            Model = "IronWolf 4TB",
            ImagePath = "seagate-ironwolf-4tb.jpg",
            InitialPrice = 119,
            DiscountPercentage = 8,
            Quantity = 20,
            Memory = new Memory(4000, MemoryType.Ddr4, Frequency.Mhz2200),
            Type = StorageType.Hdd
        },

        new()
        {
            Brand = Brands["crucial"],
            Model = "MX500 1TB",
            ImagePath = "crucial-mx500-1tb.jpg",
            InitialPrice = 89,
            DiscountPercentage = 10,
            Quantity = 25,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz3200),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["samsung"],
            Model = "870 Evo 2TB",
            ImagePath = "samsung-870-evo-2tb.jpg",
            InitialPrice = 199,
            DiscountPercentage = 6,
            Quantity = 12,
            Memory = new Memory(2000, MemoryType.Ddr4, Frequency.Mhz3200),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["western-digital"],
            Model = "Red 4TB",
            ImagePath = "western-digital-red-4tb.jpg",
            InitialPrice = 129,
            DiscountPercentage = 5,
            Quantity = 10,
            Memory = new Memory(4000, MemoryType.Ddr4, Frequency.Mhz2200),
            Type = StorageType.Hdd
        },

        new()
        {
            Brand = Brands["seagate"],
            Model = "Barracuda 1TB",
            ImagePath = "seagate-barracuda-1tb.jpg",
            InitialPrice = 45,
            DiscountPercentage = 12,
            Quantity = 50,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz2400),
            Type = StorageType.Hdd
        },

        new()
        {
            Brand = Brands["kingston"],
            Model = "A2000 500GB",
            ImagePath = "kingston-a2000-500gb.jpg",
            InitialPrice = 59,
            DiscountPercentage = 10,
            Quantity = 30,
            Memory = new Memory(500, MemoryType.Ddr4, Frequency.Mhz3000),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["adata"],
            Model = "XPG SX8200 Pro 1TB",
            ImagePath = "adata-xpg-sx8200-pro-1tb.jpg",
            InitialPrice = 119,
            DiscountPercentage = 7,
            Quantity = 18,
            Memory = new Memory(1000, MemoryType.Ddr4, Frequency.Mhz3200),
            Type = StorageType.Ssd
        },

        new()
        {
            Brand = Brands["toshiba"],
            Model = "P300 3TB",
            ImagePath = "toshiba-p300-3tb.jpg",
            InitialPrice = 79,
            DiscountPercentage = 9,
            Quantity = 22,
            Memory = new Memory(3000, MemoryType.Ddr4, Frequency.Mhz2200),
            Type = StorageType.Hdd
        }
    ];
    internal static readonly List<PowerSupply> PowerSupplies =
    [
        new()
        {
            Brand = Brands["corsair"],
            Model = "RM750x",
            ImagePath = "corsair-rm750x.jpg",
            InitialPrice = 129,
            DiscountPercentage = 10,
            Quantity = 12,
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["evga"],
            Model = "SuperNOVA 650 G5",
            ImagePath = "evga-650g5.jpg",
            InitialPrice = 109,
            DiscountPercentage = 8,
            Quantity = 15,
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["seasonic"],
            Model = "Focus GX-550",
            ImagePath = "seasonic-focus-gx-550.jpg",
            InitialPrice = 89,
            DiscountPercentage = 5,
            Quantity = 18,
            Wattage = 550,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["cooler master"],
            Model = "MWE Bronze 600",
            ImagePath = "cooler-master-mwe-600.jpg",
            InitialPrice = 69,
            DiscountPercentage = 7,
            Quantity = 20,
            Wattage = 600,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.Semi
        },

        new()
        {
            Brand = Brands["thermaltake"],
            Model = "Smart 500W",
            ImagePath = "thermaltake-smart-500.jpg",
            InitialPrice = 49,
            DiscountPercentage = 5,
            Quantity = 25,
            Wattage = 500,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.None
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "SF750",
            ImagePath = "corsair-sf750.jpg",
            InitialPrice = 189,
            DiscountPercentage = 10,
            Quantity = 8,
            Wattage = 750,
            FormFactor = FormFactor.MiniItx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["evga"],
            Model = "SuperNOVA 850 G5",
            ImagePath = "evga-850g5.jpg",
            InitialPrice = 149,
            DiscountPercentage = 7,
            Quantity = 10,
            Wattage = 850,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["seasonic"],
            Model = "Prime TX-1000",
            ImagePath = "seasonic-prime-tx-1000.jpg",
            InitialPrice = 299,
            DiscountPercentage = 5,
            Quantity = 5,
            Wattage = 1000,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 90,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["thermaltake"],
            Model = "Toughpower 750W",
            ImagePath = "thermaltake-tp-750.jpg",
            InitialPrice = 129,
            DiscountPercentage = 6,
            Quantity = 12,
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["cooler master"],
            Model = "V550",
            ImagePath = "cooler-master-v550.jpg",
            InitialPrice = 79,
            DiscountPercentage = 5,
            Quantity = 18,
            Wattage = 550,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Semi
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "CX650M",
            ImagePath = "corsair-cx650m.jpg",
            InitialPrice = 89,
            DiscountPercentage = 6,
            Quantity = 15,
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.Semi
        },

        new()
        {
            Brand = Brands["evga"],
            Model = "BT 500W",
            ImagePath = "evga-bt-500.jpg",
            InitialPrice = 49,
            DiscountPercentage = 4,
            Quantity = 20,
            Wattage = 500,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.None
        },

        new()
        {
            Brand = Brands["seasonic"],
            Model = "S12III 550W",
            ImagePath = "seasonic-s12iii-550.jpg",
            InitialPrice = 69,
            DiscountPercentage = 5,
            Quantity = 25,
            Wattage = 550,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.None
        },

        new()
        {
            Brand = Brands["thermaltake"],
            Model = "TR2 600W",
            ImagePath = "thermaltake-tr2-600.jpg",
            InitialPrice = 59,
            DiscountPercentage = 7,
            Quantity = 22,
            Wattage = 600,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.None
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "RM850x",
            ImagePath = "corsair-rm850x.jpg",
            InitialPrice = 149,
            DiscountPercentage = 8,
            Quantity = 10,
            Wattage = 850,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["evga"],
            Model = "SuperNOVA 750 G5",
            ImagePath = "evga-750g5.jpg",
            InitialPrice = 129,
            DiscountPercentage = 5,
            Quantity = 12,
            Wattage = 750,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["seasonic"],
            Model = "Prime GX-650",
            ImagePath = "seasonic-prime-gx-650.jpg",
            InitialPrice = 119,
            DiscountPercentage = 6,
            Quantity = 10,
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 90,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["cooler master"],
            Model = "MWE Gold 650",
            ImagePath = "cooler-master-mwe-gold-650.jpg",
            InitialPrice = 99,
            DiscountPercentage = 5,
            Quantity = 15,
            Wattage = 650,
            FormFactor = FormFactor.Atx,
            EfficiencyPercentage = 90,
            Modularity = Modularity.Semi
        },

        new()
        {
            Brand = Brands["thermaltake"],
            Model = "Toughpower 1000W",
            ImagePath = "thermaltake-tp-1000.jpg",
            InitialPrice = 199,
            DiscountPercentage = 6,
            Quantity = 5,
            Wattage = 1000,
            FormFactor = FormFactor.EAtx,
            EfficiencyPercentage = 85,
            Modularity = Modularity.Full
        },

        new()
        {
            Brand = Brands["corsair"],
            Model = "SF600",
            ImagePath = "corsair-sf600.jpg",
            InitialPrice = 129,
            DiscountPercentage = 7,
            Quantity = 8,
            Wattage = 600,
            FormFactor = FormFactor.MiniItx,
            EfficiencyPercentage = 80,
            Modularity = Modularity.Full
        }
    ];
    internal static readonly List<Shipping> Shippings =
    [
        new()
        {
            ShippingType = ShippingType.Express,
            Cost = 25,
            Days = 2
        },

        new()
        {
            ShippingType = ShippingType.Standard,
            Cost = 10,
            Days = 5
        },

        new()
        {
            ShippingType = ShippingType.NextDay,
            Cost = 35,
            Days = 1
        },

        new()
        {
            ShippingType = ShippingType.SameDay,
            Cost = 50,
            Days = 0
        }
    ];
    internal static readonly Dictionary<string, Country> Countries = new()
    {
        ["bulgaria"] = new Country { CountryName = "Bulgaria" },
        ["austria"] = new Country { CountryName = "Austria" },
        ["belgium"] = new Country { CountryName = "Belgium" },
        ["croatia"] = new Country { CountryName = "Croatia" },
        ["czechia"] = new Country { CountryName = "Czechia" },
        ["denmark"] = new Country { CountryName = "Denmark" },
        ["finland"] = new Country { CountryName = "Finland" },
        ["france"] = new Country { CountryName = "France" },
        ["germany"] = new Country { CountryName = "Germany" },
        ["greece"] = new Country { CountryName = "Greece" },
        ["hungary"] = new Country { CountryName = "Hungary" },
        ["italy"] = new Country { CountryName = "Italy" },
        ["netherlands"] = new Country { CountryName = "Netherlands" },
        ["poland"] = new Country { CountryName = "Poland" },
        ["portugal"] = new Country { CountryName = "Portugal" },
        ["romania"] = new Country { CountryName = "Romania" },
        ["slovakia"] = new Country { CountryName = "Slovakia" },
        ["slovenia"] = new Country { CountryName = "Slovenia" },
        ["spain"] = new Country { CountryName = "Spain" },
        ["sweden"] = new Country { CountryName = "Sweden" },
        ["uk"] = new Country { CountryName = "United Kingdom" },
        ["us"] = new Country { CountryName = "United States" }
    };
    internal static readonly List<City> Cities =
    [
        new() { Country = Countries["bulgaria"], CityName = "Sofia" },
        new() { Country = Countries["bulgaria"], CityName = "Plovdiv" },
        new() { Country = Countries["bulgaria"], CityName = "Varna" },
        new() { Country = Countries["austria"], CityName = "Vienna" },
        new() { Country = Countries["austria"], CityName = "Salzburg" },
        new() { Country = Countries["austria"], CityName = "Graz" },
        new() { Country = Countries["belgium"], CityName = "Brussels" },
        new() { Country = Countries["belgium"], CityName = "Antwerp" },
        new() { Country = Countries["belgium"], CityName = "Ghent" },
        new() { Country = Countries["croatia"], CityName = "Zagreb" },
        new() { Country = Countries["croatia"], CityName = "Split" },
        new() { Country = Countries["croatia"], CityName = "Rijeka" },
        new() { Country = Countries["czechia"], CityName = "Prague" },
        new() { Country = Countries["czechia"], CityName = "Brno" },
        new() { Country = Countries["czechia"], CityName = "Ostrava" },
        new() { Country = Countries["denmark"], CityName = "Copenhagen" },
        new() { Country = Countries["denmark"], CityName = "Aarhus" },
        new() { Country = Countries["denmark"], CityName = "Odense" },
        new() { Country = Countries["finland"], CityName = "Helsinki" },
        new() { Country = Countries["finland"], CityName = "Espoo" },
        new() { Country = Countries["finland"], CityName = "Tampere" },
        new() { Country = Countries["france"], CityName = "Paris" },
        new() { Country = Countries["france"], CityName = "Lyon" },
        new() { Country = Countries["france"], CityName = "Marseille" },
        new() { Country = Countries["germany"], CityName = "Berlin" },
        new() { Country = Countries["germany"], CityName = "Munich" },
        new() { Country = Countries["germany"], CityName = "Frankfurt" },
        new() { Country = Countries["greece"], CityName = "Athens" },
        new() { Country = Countries["greece"], CityName = "Thessaloniki" },
        new() { Country = Countries["greece"], CityName = "Patras" },
        new() { Country = Countries["hungary"], CityName = "Budapest" },
        new() { Country = Countries["hungary"], CityName = "Debrecen" },
        new() { Country = Countries["hungary"], CityName = "Szeged" },
        new() { Country = Countries["italy"], CityName = "Rome" },
        new() { Country = Countries["italy"], CityName = "Milan" },
        new() { Country = Countries["italy"], CityName = "Naples" },
        new() { Country = Countries["netherlands"], CityName = "Amsterdam" },
        new() { Country = Countries["netherlands"], CityName = "Rotterdam" },
        new() { Country = Countries["netherlands"], CityName = "The Hague" },
        new() { Country = Countries["poland"], CityName = "Warsaw" },
        new() { Country = Countries["poland"], CityName = "Krakow" },
        new() { Country = Countries["poland"], CityName = "Gdansk" },
        new() { Country = Countries["portugal"], CityName = "Lisbon" },
        new() { Country = Countries["portugal"], CityName = "Porto" },
        new() { Country = Countries["portugal"], CityName = "Coimbra" },
        new() { Country = Countries["romania"], CityName = "Bucharest" },
        new() { Country = Countries["romania"], CityName = "Cluj-Napoca" },
        new() { Country = Countries["romania"], CityName = "Timisoara" },
        new() { Country = Countries["slovakia"], CityName = "Bratislava" },
        new() { Country = Countries["slovakia"], CityName = "Kosice" },
        new() { Country = Countries["slovakia"], CityName = "Presov" },
        new() { Country = Countries["slovenia"], CityName = "Ljubljana" },
        new() { Country = Countries["slovenia"], CityName = "Maribor" },
        new() { Country = Countries["slovenia"], CityName = "Kranj" },
        new() { Country = Countries["spain"], CityName = "Madrid" },
        new() { Country = Countries["spain"], CityName = "Barcelona" },
        new() { Country = Countries["spain"], CityName = "Valencia" },
        new() { Country = Countries["sweden"], CityName = "Stockholm" },
        new() { Country = Countries["sweden"], CityName = "Gothenburg" },
        new() { Country = Countries["sweden"], CityName = "Malmo" },
        new() { Country = Countries["uk"], CityName = "London" },
        new() { Country = Countries["uk"], CityName = "Manchester" },
        new() { Country = Countries["uk"], CityName = "Birmingham" },
        new() { Country = Countries["us"], CityName = "New York" },
        new() { Country = Countries["us"], CityName = "Los Angeles" },
        new() { Country = Countries["us"], CityName = "Chicago" }
    ];
}